classCommentText
	"return the text to display for the comment of the currently selected class"
	| theClass |
	theClass _ self selectedClassOrMetaClass.
	theClass ifNil: [ ^''].

	^ theClass hasComment
		ifTrue: [  theClass comment  ]
		ifFalse: [ self noCommentNagString ]