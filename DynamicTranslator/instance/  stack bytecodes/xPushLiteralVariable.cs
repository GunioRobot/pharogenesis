xPushLiteralVariable
	"	010xxxxx		pushLiteralVariable: xxxxx

	=>	PushLiteralVariable
		association"

	self emitOp: PushLiteralVariable.
	self emitLiteralVariable: (currentByte bitAnd: 31)