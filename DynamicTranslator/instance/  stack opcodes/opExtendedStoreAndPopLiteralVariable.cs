opExtendedStoreAndPopLiteralVariable

	self inline: true.
	(self initOp: ExtendedStoreAndPopLiteralVariable) ifFalse: [
	self beginOp: ExtendedStoreAndPopLiteralVariable.

		self storePointer: ValueIndex ofObject: (self fetchLiteralVariable) withValue: self internalStackTop.
		self internalPop: 1.
		self skip: 2.

	self endOp: ExtendedStoreAndPopLiteralVariable
	].