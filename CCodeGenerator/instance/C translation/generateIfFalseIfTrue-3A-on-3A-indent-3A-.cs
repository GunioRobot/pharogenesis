generateIfFalseIfTrue: msgNode on: aStream indent: level
	"Generate the C code for this message onto the given stream."
	"Note: PP 2.3 compiler reverses the argument blocks for ifFalse:ifTrue:,
       presumably to help with inlining later. That is, the first argument
       is the block to be evaluated if the condition is true. Squeak's compiler
	  does not reverse the blocks, but you may need to fix this method if
	  you wish to cross-compile using VisualWorks."

	| const |
	const _ self nilOrBooleanConstantReceiverOf: msgNode.
	const ifNotNil: [
		const
			ifTrue: [msgNode args last emitCCodeOn: aStream level: level generator: self]
			ifFalse: [msgNode args first emitCCodeOn: aStream level: level generator: self].
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