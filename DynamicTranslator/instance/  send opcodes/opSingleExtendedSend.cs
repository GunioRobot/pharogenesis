opSingleExtendedSend
	"	0:	SingleExtendedSend
		1:	numArgs
		2:	nil
		3:	selector"

	(self initOp: SingleExtendedSend) ifFalse: [
	self beginOp: SingleExtendedSend.

		self skip: 3.
		self unlinkedSend: (self peekLiteral: 0) nArgs: (self peekInteger: -2) type: ExtendedSendType.

	self endOp: SingleExtendedSend
	]