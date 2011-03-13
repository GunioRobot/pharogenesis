noUndoReplace: anInterval with: aText
"This is the zap that multilevel undo uses to do edits. This method bypasses any undo/redo plumbing (in contrast to zapSelection:).  This method is called by an EditCommand (which wants to carry out its paragraph surgery without adding another command to the editHistory)"

	| start stop |
	self deselect.
	start _ (anInterval first max: 1).
	stop _ (anInterval last min: paragraph text size).
	(aText isEmpty and: [stop > start]) ifTrue:
		["If deleting, then set emphasisHere from 1st character of the deletion"
		emphasisHere _ (paragraph text attributesAt: start forStyle: paragraph textStyle)
					select: [:att | att mayBeExtended]].
"Debug dShow: ('zap start->stop: ', (start to: stop) asString)."
	paragraph 
		replaceFrom: start 
		to: stop 
		with: aText 
		displaying: false.  

	UndoMessage sends: #noUndoer . "Keep the normal undo machine happy"
	self userHasEdited  " -- note text now dirty"
