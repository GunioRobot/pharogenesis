opSendLiteralSelector2
	"	0:	SendLiteralSelector2
		1:	selector"

	(self initOp: SendLiteralSelector2) ifFalse: [
	self beginOp: SendLiteralSelector2.

		self unlinkedSend: self fetchLiteral nArgs: 2 type: ShortSendType.

	self endOp: SendLiteralSelector2
	]