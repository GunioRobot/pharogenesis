opDoubleExtendedNormalSend
	"	0:	DoubleExtendedNormalSend
		1:	nil
		2:	nil
		3:	nil
		4:	nil
		5:	method"

	(self initOp: DoubleExtendedNormalSend) ifFalse: [
	self beginOp: DoubleExtendedNormalSend.

		self skip: 5.
		self normalSend: (self peekLiteral: 0) type: DoubleExtendedSendType.

	self endOp: DoubleExtendedNormalSend
	]