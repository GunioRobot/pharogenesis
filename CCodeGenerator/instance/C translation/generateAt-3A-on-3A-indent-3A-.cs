generateAt: msgNode on: aStream indent: level
	"Generate the C code for this message onto the given stream."

	self emitCExpression: msgNode receiver on: aStream.
	aStream nextPutAll: '['.
	msgNode args first emitCCodeOn: aStream level: level generator: self.
	aStream nextPutAll: ']'.