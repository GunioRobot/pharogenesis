generateWhileFalse: msgNode on: aStream indent: level
	"Generate the C code for this message onto the given stream."

	aStream nextPutAll: 'while (!('.
	self emitCTestBlock: msgNode receiver on: aStream.
	aStream nextPutAll: ')) {'; cr.
	msgNode args first emitCCodeOn: aStream level: level + 1 generator: self.
	level timesRepeat: [ aStream tab ].
	aStream nextPutAll: '}'.