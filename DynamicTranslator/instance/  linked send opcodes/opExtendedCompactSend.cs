opExtendedCompactSend
	"	0:	ExtendedCompactSend
		1:	nil
		2:	nil
		3:	method"

	(self initOp: ExtendedCompactSend) ifFalse: [
	self beginOp: ExtendedCompactSend.

		self skip: 3.
		self compactSend: (self peekLiteral: 0) type: ExtendedSendType.

	self endOp: ExtendedCompactSend
	]