opExtendedStoreAndPopTemporaryVariable

	self inline: true.
	(self initOp: ExtendedStoreAndPopTemporaryVariable) ifFalse: [
	self beginOp: ExtendedStoreAndPopTemporaryVariable.

		self temporary: (self fetchInteger) put: self internalStackTop.
		self internalPop: 1.
		self skip: 2.

	self endOp: ExtendedStoreAndPopTemporaryVariable
	].