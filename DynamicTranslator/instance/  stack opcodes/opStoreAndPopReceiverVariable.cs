opStoreAndPopReceiverVariable

	(self initOp: StoreAndPopReceiverVariable) ifFalse: [
	self beginOp: StoreAndPopReceiverVariable.

		self storeAndPopReceiverVariable: (self fetchInteger).

	self endOp: StoreAndPopReceiverVariable
	]

"
	| rcvr top |
	self skip: 1.
	rcvr _ self internalReceiver.
	top _ self internalStackTop.
	(rcvr < youngStart) ifTrue: [
		self possibleRootStoreInto: rcvr value: top.
	].
	self storePointerUnchecked: (currentBytecode bitAnd: 7)
		ofObject: rcvr
		withValue: top.
	self internalPop: 1.
"