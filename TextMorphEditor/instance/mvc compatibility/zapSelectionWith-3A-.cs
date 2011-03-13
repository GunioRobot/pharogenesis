zapSelectionWith: aText
	"**overridden to inhibit old-style display"
	| start stop |
	self deselect.
	start _ startBlock stringIndex.
	stop _ stopBlock stringIndex.
	(start = stop and: [aText size = 0]) ifFalse:
		[paragraph replaceFrom: start to: stop - 1
			with: aText displaying: false.  "** was true in super"
		self computeIntervalFrom: start to: start + aText size - 1.
		UndoInterval _ otherInterval _ self selectionInterval].

	self userHasEdited  " -- note text now dirty"