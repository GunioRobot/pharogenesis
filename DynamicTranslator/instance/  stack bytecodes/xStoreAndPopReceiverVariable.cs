xStoreAndPopReceiverVariable
	"	01100xxx		storeAndPopReceiverVariable: xxx

	=>	StoreAndPopReceiverVariable
		xxx"

	"	-4	PushTempVar	_	MacroMoveTempRcvr
		-0	<SmallInteger>"
	self rewrite: -4 from: PushTemporaryVariable to: MacroMoveTempRcvr.

	self emitOp: StoreAndPopReceiverVariable.
	self emitInteger: (currentByte bitAnd: 7).