containingWindow
	"Answer the window in which the receiver is seen"

	^ super containingWindow ifNil:
		[Smalltalk isMorphic ifFalse: [self currentWorld]]