multiUndoWithCount: count

	| command i lastCommand saveSelection newSelection history |

	count > 0 ifFalse:[ ^self ].
	history _ self editHistory.
	(command _ history commandToUndo) 
		ifNil:[ ^self multiUndoError: 'Nothing to undo'].
		
	saveSelection _ self selectionInterval.
	self deselect.
	i _ 0.
	[i < count] whileTrue: 
		[history undo.
		lastCommand _ command.
		((i _ i + 1) < count) ifTrue:
			[(command _ history commandToUndo) ifNil:[
				self multiUndoError: ('Only ', (i - 1) asString, ' commands to undo.').
				i _ count. ]]].

	(newSelection _ lastCommand undoSelectionInterval) isNil
			ifTrue:[ self selectInterval: saveSelection]
			ifFalse:[ self selectInterval: newSelection].

