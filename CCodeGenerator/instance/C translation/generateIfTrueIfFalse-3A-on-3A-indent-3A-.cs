generateIfTrueIfFalse: msgNode on: aStream indent: level
	"Generate the C code for this message onto the given stream."

	aStream nextPutAll: 'if ('.
	msgNode receiver emitCCodeOn: aStream level: level generator: self.
	aStream nextPutAll: ') {'; cr.
	msgNode args first emitCCodeOn: aStream level: level + 1 generator: self.
	level timesRepeat: [ aStream tab ].
	aStream nextPutAll: '} else {'; cr.
	msgNode args last emitCCodeOn: aStream level: level + 1 generator: self.
	level timesRepeat: [ aStream tab ].
	aStream nextPutAll: '}'.