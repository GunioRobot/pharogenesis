storeAndPopTemporaryVariable: temporaryIndex

	self temporary: (temporaryIndex) put: self internalStackTop.
	self internalPop: 1.
