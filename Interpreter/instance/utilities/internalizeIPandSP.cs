internalizeIPandSP
	"Copy the local instruction and stack pointer to local variables for rapid access within the interpret loop."

	localIP _ self cCoerce: instructionPointer to: 'char *'.
	localSP _ self cCoerce: stackPointer to: 'char *'.
