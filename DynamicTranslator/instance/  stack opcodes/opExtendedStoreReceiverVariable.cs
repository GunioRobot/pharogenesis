opExtendedStoreReceiverVariable

	self inline: true.
	(self initOp: ExtendedStoreReceiverVariable) ifFalse: [
	self beginOp: ExtendedStoreReceiverVariable.

		self storePointer: (self fetchInteger) ofObject: self internalReceiver withValue: self internalStackTop.
		self skip: 2.

	self endOp: ExtendedStoreReceiverVariable
	].