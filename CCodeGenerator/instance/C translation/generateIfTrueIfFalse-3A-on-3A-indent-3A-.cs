generateIfTrueIfFalse: msgNode on: aStream indent: level
	"Generate the C code for this message onto the given stream."

	| const |
	const _ self nilOrBooleanConstantReceiverOf: msgNode.
	const ifNotNil: [
		const
			ifTrue: [msgNode args first emitCCodeOn: aStream level: level generator: self]
			ifFalse: [msgNode args last emitCCodeOn: aStream level: level generator: self].
		^ self].

	aStream nextPutAll: 'if ('.
	msgNode receiver emitCCodeOn: aStream level: level generator: self.
	aStream nextPutAll: ') {'; cr.
	msgNode args first emitCCodeOn: aStream level: level + 1 generator: self.
	level timesRepeat: [ aStream tab ].
	aStream nextPutAll: '} else {'; cr.
	msgNode args last emitCCodeOn: aStream level: level + 1 generator: self.
	level timesRepeat: [ aStream tab ].
	aStream nextPutAll: '}'.