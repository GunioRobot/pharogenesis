zapSelectionWith: aText
	"**overridden to inhibit old-style display"
	| start stop rText rInterval isInTypeRun |
	self deselect.
	start _ self startIndex.
	stop _ self stopIndex.
	(aText isEmpty and: [stop > start]) ifTrue:
		["If deleting, then set emphasisHere from 1st character of the deletion"
		emphasisHere _ (paragraph text attributesAt: start forStyle: paragraph textStyle)
					select: [:att | att mayBeExtended]].
	(start = stop and: [aText size = 0]) ifFalse:
		[
		"===Support for multilevel undo start ==="
		rText _ (paragraph text copyFrom: start to: (stop - 1)).
		rInterval _ start to: (stop - 1).
		isInTypeRun _ self isInTypeRun.
		"===Support for multilevel undo end ==="
		
		paragraph replaceFrom: start to: stop - 1
			with: aText displaying: false.  "** was true in super"
		self computeIntervalFrom: start to: start + aText size - 1.
		UndoInterval _ otherInterval _ self selectionInterval.

		"===Support for multilevel undo start ==="
		 (Preferences multipleTextUndo and: [isInTypeRun not])ifTrue:
				[ self addEditCommand: 
							(EditCommand
									textMorph: morph
									replacedText: rText
									replacedTextInterval: rInterval
									newText: aText 
									newTextInterval: super selectionInterval)].
		"===Support for multilevel undo end ==="].

	self userHasEdited  " -- note text now dirty"