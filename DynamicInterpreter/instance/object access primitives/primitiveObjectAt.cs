primitiveObjectAt  "Defined for CompiledMethods only"
	| thisReceiver index |
	index  _ self popInteger.
	thisReceiver _ self popStack.
	self success: index > 0.
	self success: index <= ((self literalCountOf: thisReceiver) + LiteralStart).
	successFlag
		ifTrue: [self push: (self fetchPointer: index - 1
					ofObject: thisReceiver)]
		ifFalse: [self unPop: 2]