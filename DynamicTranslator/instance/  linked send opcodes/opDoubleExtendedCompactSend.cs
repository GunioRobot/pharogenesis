opDoubleExtendedCompactSend
	"	0:	DoubleExtendedCompactSend
		1:	nil
		2:	nil
		3:	nil
		4:	nil
		5:	method"

	(self initOp: DoubleExtendedCompactSend) ifFalse: [
	self beginOp: DoubleExtendedCompactSend.

		self skip: 5.
		self compactSend: (self peekLiteral: 0) type: DoubleExtendedSendType.

	self endOp: DoubleExtendedCompactSend
	]