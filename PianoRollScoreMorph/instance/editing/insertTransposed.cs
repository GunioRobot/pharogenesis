insertTransposed
	| delta transposedNotes |
	(delta := (SelectionMenu 
				selections: ((12 to: -12 by: -1) collect: [:i | i printString])) 
					startUpWithCaption: 'offset...') ifNil: [^self].
	transposedNotes := NotePasteBuffer 
				collect: [:note | note copy midiKey: note midiKey + delta].
	selection isNil ifTrue: [^self].
	score insertEvents: transposedNotes at: self selection.
	scorePlayer updateDuration.
	self rebuildFromScore