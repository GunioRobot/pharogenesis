opLinkedCompactSend
	"	0:	LinkedCompactSend
		1:	method"

	(self initOp: LinkedCompactSend) ifFalse: [
	self beginOp: LinkedCompactSend.

		self compactSend: self fetchLiteral type: ShortSendType.

	self endOp: LinkedCompactSend
	]