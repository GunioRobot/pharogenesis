opExtendedStoreTemporaryVariable

	self inline: true.
	(self initOp: ExtendedStoreTemporaryVariable) ifFalse: [
	self beginOp: ExtendedStoreTemporaryVariable.

		self temporary: (self fetchInteger) put: self internalStackTop.
		self skip: 2.

	self endOp: ExtendedStoreTemporaryVariable
	].