primitiveNewMethod
	| header bytecodeCount class size theNewMethod literalCount |
	header _ self popStack.
	bytecodeCount _ self popInteger.
	self success: (self isIntegerObject: header).
	successFlag ifFalse: [self unPop: 2].
	class _ self popStack.
	size _ (self literalCountOfHeader: header) + 1 * 4 + bytecodeCount.
	theNewMethod _ self instantiateClass: class indexableSize: size.
	self storePointer: HeaderIndex ofObject: theNewMethod withValue: header.
	literalCount _ self literalCountOfHeader: header.
	1 to: literalCount do:
		[:i | self storePointer: i ofObject: theNewMethod withValue: nilObj].
	self push: theNewMethod