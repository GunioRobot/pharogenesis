opPrimEquivalent

	| rcvr arg |
	(self initOp: PrimEquivalent) ifFalse: [
	self beginOp: PrimEquivalent.

		rcvr _ self internalStackValue: 1.
		arg _ self internalStackValue: 0.
		self internalPop: 2 thenPushBool: rcvr = arg.
		self skip: 1.

	self endOp: PrimEquivalent
	].