opSendLiteralSelector0
	"	0:	SendLiteralSelector0
		1:	selector"

	(self initOp: SendLiteralSelector0) ifFalse: [
	self beginOp: SendLiteralSelector0.

		self unlinkedSend: self fetchLiteral nArgs: 0 type: ShortSendType.

	self endOp: SendLiteralSelector0
	]