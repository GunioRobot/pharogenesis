opExtendedNormalSend
	"	0:	ExtendedNormalSend
		1:	nil
		2:	nil
		3:	method"

	(self initOp: ExtendedNormalSend) ifFalse: [
	self beginOp: ExtendedNormalSend.

		self skip: 3.
		self normalSend: (self peekLiteral: 0) type: ExtendedSendType.

	self endOp: ExtendedNormalSend
	]