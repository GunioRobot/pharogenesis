primitiveObjectAtPut  "Defined for CompiledMethods only"
	| thisReceiver index newValue |
	newValue _ self popStack.
	index _ self popInteger.
	thisReceiver _ self popStack.
	self success: index > 0.
	self success: index <= ((self literalCountOf: thisReceiver) + LiteralStart).
	successFlag
		ifTrue: [self storePointer: index - 1
				ofObject: thisReceiver
				withValue: newValue.
			self push: newValue]
		ifFalse: [self unPop: 3]