externalizeIPandSP
	"Copy the local instruction and stack pointer to global variables for use in primitives and other functions outside the interpret loop."

	self internalSetInstructionPointer: (self cCoerce: localIP to: 'int').
	self internalSetStackPointer: (self cCoerce: localSP to: 'int').
