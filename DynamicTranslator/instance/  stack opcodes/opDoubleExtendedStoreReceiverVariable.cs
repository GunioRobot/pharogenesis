opDoubleExtendedStoreReceiverVariable

	self inline: true.
	(self initOp: DoubleExtendedStoreReceiverVariable) ifFalse: [
	self beginOp: DoubleExtendedStoreReceiverVariable.

		self storePointer: (self fetchInteger) ofObject: self internalReceiver withValue: self internalStackTop.
		self skip: 4.

	self endOp: DoubleExtendedStoreReceiverVariable
	].