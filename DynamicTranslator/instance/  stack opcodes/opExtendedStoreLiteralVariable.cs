opExtendedStoreLiteralVariable

	self inline: true.
	(self initOp: ExtendedStoreLiteralVariable) ifFalse: [
	self beginOp: ExtendedStoreLiteralVariable.

		self storePointer: ValueIndex ofObject: (self fetchLiteralVariable) withValue: self internalStackTop.
		self skip: 2.

	self endOp: ExtendedStoreLiteralVariable
	].