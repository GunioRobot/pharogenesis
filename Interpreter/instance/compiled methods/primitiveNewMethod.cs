primitiveNewMethod
	| header bytecodeCount class size theMethod literalCount |
	header _ self popStack.
	bytecodeCount _ self popInteger.
	self success: (self isIntegerObject: header).
	successFlag ifFalse: [self unPop: 2].
	class _ self popStack.
	size _ (self literalCountOfHeader: header) + 1 * 4 + bytecodeCount.
	theMethod _ self instantiateClass: class indexableSize: size.
	self storePointer: HeaderIndex ofObject: theMethod withValue: header.
	literalCount _ self literalCountOfHeader: header.
	1 to: literalCount do:
		[:i | self storePointer: i ofObject: theMethod withValue: nilObj].
	self push: theMethod