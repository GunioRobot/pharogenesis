opDoubleExtendedStoreLiteralVariable

	self inline: true.
	(self initOp: DoubleExtendedStoreLiteralVariable) ifFalse: [
	self beginOp: DoubleExtendedStoreLiteralVariable.

		self storePointer: ValueIndex ofObject: (self fetchLiteralVariable) withValue: self internalStackTop.
		self skip: 4.

	self endOp: DoubleExtendedStoreLiteralVariable
	].