fullyExpandStack
	"Expand the stack to include all of it, rather than the first four or five
	contexts."

	self okToChange ifFalse: [^ self].
	self newStack: contextStackTop contextStack.
	self changed: #contextStackList