opDoubleExtendedSuper
	"	0:	DoubleExtendedSuper
		1:	numArgs
		2:	nil
		3:	nil
		4:	nil
		5:	selector"

	(self initOp: DoubleExtendedSuper) ifFalse: [
	self beginOp: DoubleExtendedSuper.

		argumentCount _ self peekInteger: 1.
		messageSelector _ self peekLiteralSelector: 5.
		self skip: 5.		"do this before send, in case of doesNotUnderstand"
		self superclassSend.

	self endOp: DoubleExtendedSuper
	]
