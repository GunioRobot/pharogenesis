opDoubleExtendedImmediateSend
	"	0:	DoubleExtendedImmediateSend
		1:	nil
		2:	nil
		3:	nil
		4:	nil
		5:	method"

	(self initOp: DoubleExtendedImmediateSend) ifFalse: [
	self beginOp: DoubleExtendedImmediateSend.

		self skip: 5.
		self immediateSend: (self peekLiteral: 0) type: DoubleExtendedSendType.

	self endOp: DoubleExtendedImmediateSend
	]