opLinkedImmediateSend
	"	0:	LinkedImmediateSend
		1:	method"

	(self initOp: LinkedImmediateSend) ifFalse: [
	self beginOp: LinkedImmediateSend.

		self immediateSend: self fetchLiteral type: ShortSendType.

	self endOp: LinkedImmediateSend
	]