multiRedoWithCount: count

	| command i lastCommand newSelection saveSelection history |

	count > 0 ifFalse:[ ^self ].

	history _ self editHistory.
	(command _ history nextCommand) isNil
			ifTrue:[ ^self multiUndoError: 'Nothing to redo'].

	saveSelection _ self selectionInterval.
	self deselect.
	i _ 0.
	[i < count] whileTrue: 
		[
		history redo.
		lastCommand _ command.
		((i _ i + 1) < count) ifTrue:
			[
			(command _ history nextCommand) ifNil:[
				self multiUndoError: ('Only ', (i - 1) asString, ' commands to redo.').
				i _ count.]]].

	(newSelection _ lastCommand redoSelectionInterval) isNil
			ifTrue:[ self selectInterval: saveSelection]
			ifFalse:[ self selectInterval: newSelection].

