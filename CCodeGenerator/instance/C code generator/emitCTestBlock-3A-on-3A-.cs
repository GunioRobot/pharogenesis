emitCTestBlock: aBlockNode on: aStream
	"Emit C code for the given block node to be used as a loop test."

	aBlockNode statements size > 1 ifTrue: [
		aBlockNode emitCCodeOn: aStream level: 0 generator: self.
	] ifFalse: [
		aBlockNode statements first emitCCodeOn: aStream level: 0 generator: self.
	].