undoMenuWording
	"Answer the wording to be used in an 'undo' menu item"

	(((lastCommand == nil or: [Preferences useUndo not]) or:
		[Preferences infiniteUndo not and: [lastCommand phase == #undone]])  or: 
			[self nextCommandToUndo == nil]) ifTrue: [^ 'can''t undo'].

	^ String streamContents:
		[:aStream | 
			aStream nextPutAll: 'undo "'.
			aStream nextPutAll: (self nextCommandToUndo cmdWording truncateTo: 12).
			aStream nextPut: $".
			lastCommand phase == #done ifTrue:
				[aStream nextPutAll: ' (z)']]