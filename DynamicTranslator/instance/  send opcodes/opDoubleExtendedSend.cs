opDoubleExtendedSend
	"	0:	DoubleExtendedSend
		1:	numArgs
		2:	nil
		3:	nil
		4:	nil
		5:	selector | translatedMethod"

	(self initOp: DoubleExtendedSend) ifFalse: [
	self beginOp: DoubleExtendedSend.

		self skip: 5.
		self unlinkedSend: (self peekLiteral: 0) nArgs: (self peekInteger: -4) type: DoubleExtendedSendType.

	self endOp: DoubleExtendedSend
	]
