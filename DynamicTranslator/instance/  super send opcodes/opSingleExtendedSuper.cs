opSingleExtendedSuper
	"	0:	SingleExtendedSuper
		1:	numArgs
		2:	nil
		3:	selector"

	(self initOp: SingleExtendedSuper) ifFalse: [
	self beginOp: SingleExtendedSuper.

		argumentCount _ self peekInteger: 1.
		messageSelector _ self peekLiteralSelector: 3.
		self skip: 3.
		self superclassSend.

	self endOp: SingleExtendedSuper
	]