primitiveClone
	"Return a shallow copy of the receiver."

	| newCopy |
	newCopy _ self clone: (self stackTop).
	self pop: 1 thenPush: newCopy.