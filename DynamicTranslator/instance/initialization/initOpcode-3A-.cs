initOpcode: index

	self inline: false.
	opcodeIndex _ index - 1.
	self assert: self interpreterInitializing.
	self interpret.	"leaves opcode address in opcodeAddress"
	(self isIntegerObject: opcodeAddress) ifFalse:
		[self error: 'opcode address is not an integer object'].
	opcodeTable at: index put: opcodeAddress