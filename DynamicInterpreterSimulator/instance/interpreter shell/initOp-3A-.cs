initOp: opIndex
	"Defined as a macro in translated code, in the simulator this must
	store the 'address' of the opcode in opcodeAddress and then answer
	'true' during initialisation, or simply answer 'false' when executing."

	self interpreterInitializing ifFalse: [^false].
	opcodeAddress _ self integerObjectOf: (opIndex - 1).
	self assert: opcodeAddress == (self integerObjectOf: opcodeIndex).
	^true