undoMenuWording
	"Answer the wording to be used in an 'undo' menu item"

	(((lastCommand isNil or: [Preferences useUndo not]) 
		or: [Preferences infiniteUndo not and: [lastCommand phase == #undone]]) 
			or: [self nextCommandToUndo isNil]) ifTrue: [^'can''t undo'].
	^String streamContents: 
			[:aStream | 
			aStream nextPutAll: 'undo "'.
			aStream 
				nextPutAll: (self nextCommandToUndo cmdWording truncateWithElipsisTo: 20).
			aStream nextPut: $".
			lastCommand phase == #done ifTrue: [aStream nextPutAll: ' (z)']]