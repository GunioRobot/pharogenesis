xPushTemporaryVariable
	"	0001xxxx		pushTemporaryVariable: xxxx

	=>	PushTemporaryVariable
		xxxx"

	"	-4	PushTempVar	_	MacroPushTempTemp
		-0	<SmallInteger>"
	self rewrite: -4 from: PushTemporaryVariable to: MacroPushTempTemp.

	"	-4	PushInstVar	_	MacroPushInstTemp
		-0	<SmallInteger>"
	self rewrite: -4 from: PushReceiverVariable to: MacroPushInstTemp.

	self emitOp: PushTemporaryVariable.
	self emitInteger: (currentByte bitAnd: 15).