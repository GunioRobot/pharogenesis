zapSelectionWith: aText
	"Deselect, and replace the selection text by aText.
	 Remember the resulting selectionInterval in UndoInterval and otherInterval.
	 Do not set up for undo."

	| start stop |
	self deselect.
	start _ self startIndex.
	stop _ self stopIndex.
	(aText isEmpty and: [stop > start]) ifTrue:
		["If deleting, then set emphasisHere from 1st character of the deletion"
		emphasisHere _ (paragraph text attributesAt: start forStyle: paragraph textStyle)
					select: [:att | att mayBeExtended]].
	(start = stop and: [aText size = 0]) ifFalse:
		[paragraph
			replaceFrom: start
			to: stop - 1
			with: aText
			displaying: true.
		self computeIntervalFrom: start to: start + aText size - 1.
		UndoInterval _ otherInterval _ self selectionInterval]