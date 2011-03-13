multiRedoWithCount: count

	| command i lastCommand newSelection saveSelection history |

	count > 0 ifFalse:[ ^self ].

	history := self editHistory.
	(command := history nextCommand) isNil
			ifTrue:[ ^self multiUndoError: 'Nothing to redo'].

	saveSelection := self selectionInterval.
	self deselect.
	i := 0.
	[i < count] whileTrue: 
		[
		history redo.
		lastCommand := command.
		((i := i + 1) < count) ifTrue:
			[
			(command := history nextCommand) ifNil:[
				self multiUndoError: ('Only ', (i - 1) asString, ' commands to redo.').
				i := count.]]].

	(newSelection := lastCommand redoSelectionInterval) isNil
			ifTrue:[ self selectInterval: saveSelection]
			ifFalse:[ self selectInterval: newSelection].

