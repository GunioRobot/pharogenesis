insertTransposed

	| delta transposedNotes |
	(delta _ (SelectionMenu selections: ((12 to: -12 by: -1) collect: [:i | i printString]))
			startUpWithCaption: 'offset...') ifNil: [^ self].
	transposedNotes _ NotePasteBuffer collect: [:note | note copy midiKey: note midiKey + delta].
	selection == nil ifTrue: [^ self].
	score insertEvents: transposedNotes at: self selection.
	scorePlayer updateDuration.
	self rebuildFromScore