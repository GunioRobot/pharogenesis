opExtendedStoreAndPopReceiverVariable

	self inline: true.
	(self initOp: ExtendedStoreAndPopReceiverVariable) ifFalse: [
	self beginOp: ExtendedStoreAndPopReceiverVariable.

		self storePointer: (self fetchInteger) ofObject: self internalReceiver withValue: self internalStackTop.
		self internalPop: 1.
		self skip: 2.

	self endOp: ExtendedStoreAndPopReceiverVariable
	].