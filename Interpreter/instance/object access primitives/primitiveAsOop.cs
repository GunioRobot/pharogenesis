primitiveAsOop
	| thisReceiver |
	thisReceiver _ self popStack.
	self success: (self isIntegerObject: thisReceiver) not.
	successFlag
		ifTrue: [self pushInteger: (self hashBitsOf: thisReceiver)]
		ifFalse: [self unPop: 1]