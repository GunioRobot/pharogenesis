execOp: opIndex
	"transfer control to the opcode with the given index (this is a macro in translated code)"

	^self dispatchOn: (self integerValueOf: opIndex) in: OpcodeTable.