xPushReceiverVariable
	"	0000xxxx	pushReceiverVariable: xxxx

	=>	PushReceiverVariable
		xxxx"

	self emitOp: PushReceiverVariable.
	self emitInteger: (currentByte bitAnd: 15)
