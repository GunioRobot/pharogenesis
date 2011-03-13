multiUndoWithCount: count

	| command i lastCommand saveSelection newSelection history |

	count > 0 ifFalse:[ ^self ].
	history := self editHistory.
	(command := history commandToUndo) 
		ifNil:[ ^self multiUndoError: 'Nothing to undo'].
		
	saveSelection := self selectionInterval.
	self deselect.
	i := 0.
	[i < count] whileTrue: 
		[history undo.
		lastCommand := command.
		((i := i + 1) < count) ifTrue:
			[(command := history commandToUndo) ifNil:[
				self multiUndoError: ('Only ', (i - 1) asString, ' commands to undo.').
				i := count. ]]].

	(newSelection := lastCommand undoSelectionInterval) isNil
			ifTrue:[ self selectInterval: saveSelection]
			ifFalse:[ self selectInterval: newSelection].

