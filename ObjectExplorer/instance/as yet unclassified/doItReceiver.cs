doItReceiver
	"Answer the object that should be informed of the result of evaluating a
	text selection."

	currentSelection ifNil: [^rootObject].
	^currentSelection withoutListWrapper
