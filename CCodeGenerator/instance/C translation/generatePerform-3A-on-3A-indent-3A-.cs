generatePerform: msgNode on: aStream indent: level
	"Generate the C code for this message onto the given stream."

	self emitCExpression: msgNode args first on: aStream.
	aStream nextPutAll: '('.
	(msgNode args copyFrom: 2 to: msgNode args size) do:[:arg|
		self emitCExpression: arg on: aStream.
	] separatedBy:[aStream nextPutAll:', '].
	aStream nextPutAll:')'.