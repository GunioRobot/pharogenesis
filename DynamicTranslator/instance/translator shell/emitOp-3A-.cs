emitOp: opIndex
	"Assumes: support code makes all opcode addresses look like Smallintegers"

	self emitLiteral: (opcodeTable at: opIndex)