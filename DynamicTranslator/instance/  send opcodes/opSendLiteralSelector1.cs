opSendLiteralSelector1
	"	0:	SendLiteralSelector1
		1:	selector"

	(self initOp: SendLiteralSelector1) ifFalse: [
	self beginOp: SendLiteralSelector1.

		self unlinkedSend: self fetchLiteral nArgs: 1 type: ShortSendType.

	self endOp: SendLiteralSelector1
	]