opLinkedNormalSend
	"	0:	LinkedNormalSend
		1:	method"

	(self initOp: LinkedNormalSend) ifFalse: [
	self beginOp: LinkedNormalSend.

		self normalSend: self fetchLiteral type: ShortSendType.

	self endOp: LinkedNormalSend
	]