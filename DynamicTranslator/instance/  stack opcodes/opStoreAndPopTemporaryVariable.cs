opStoreAndPopTemporaryVariable

	(self initOp: StoreAndPopTemporaryVariable) ifFalse: [
	self beginOp: StoreAndPopTemporaryVariable.

		self storeAndPopTemporaryVariable: (self fetchInteger).

	self endOp: StoreAndPopTemporaryVariable
	]
"
	self skip: 1.
	self temporary: (currentBytecode bitAnd: 7) put: self internalStackTop.
	self internalPop: 1.
"