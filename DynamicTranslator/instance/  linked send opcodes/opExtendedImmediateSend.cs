opExtendedImmediateSend
	"	0:	ExtendedImmediateSend
		1:	nil
		2:	nil
		3:	method"

	(self initOp: ExtendedImmediateSend) ifFalse: [
	self beginOp: ExtendedImmediateSend.

		self skip: 3.
		self immediateSend: (self peekLiteral: 0) type: ExtendedSendType.

	self endOp: ExtendedImmediateSend
	]