initOpcode: index
	super initOpcode: index.
	self assert: opcodeAddress == (self integerObjectOf: index - 1)