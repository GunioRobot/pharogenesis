redoMenuWording
	"Answer the wording to be used in a menu offering the current Redo command"

	| nextCommand |
	((nextCommand := self nextCommand) isNil or: [Preferences useUndo not]) 
		ifTrue: [^'can''t redo'].
	^String streamContents: 
			[:aStream | 
			aStream nextPutAll: 'redo "'.
			aStream nextPutAll: (nextCommand cmdWording truncateWithElipsisTo: 20).
			aStream nextPut: $".
			lastCommand phase == #done ifFalse: [aStream nextPutAll: ' (z)']]