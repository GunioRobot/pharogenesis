opDoubleExtendedStoreAndPopReceiverVariable

	self inline: true.
	(self initOp: DoubleExtendedStoreAndPopReceiverVariable) ifFalse: [
	self beginOp: DoubleExtendedStoreAndPopReceiverVariable.

		self storePointer: (self fetchInteger) ofObject: self internalReceiver withValue: self internalStackTop.
		self internalPop: 1.
		self skip: 4.

	self endOp: DoubleExtendedStoreAndPopReceiverVariable
	].