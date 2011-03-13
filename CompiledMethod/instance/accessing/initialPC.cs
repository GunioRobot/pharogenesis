initialPC
	"Answer the program counter for the receiver's first bytecode."

	^ (self numLiterals + 1) * 4 + 1