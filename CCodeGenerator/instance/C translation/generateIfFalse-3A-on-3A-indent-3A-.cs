generateIfFalse: msgNode on: aStream indent: level
	"Generate the C code for this message onto the given stream."
	"Note: PP 2.3 compiler produces two arguments for ifFalse:, presumably
	 to help with inlining later. Taking the last agument should do the correct
	 thing even if your compiler is different."

	aStream nextPutAll: 'if (!('.
	msgNode receiver emitCCodeOn: aStream level: level generator: self.
	aStream nextPutAll: ')) {'; cr.
	msgNode args last emitCCodeOn: aStream level: level + 1 generator: self.
	level timesRepeat: [ aStream tab ].
	aStream nextPutAll: '}'.