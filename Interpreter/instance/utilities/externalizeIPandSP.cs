externalizeIPandSP
	"Copy the local instruction and stack pointer to global variables for use in primitives and other functions outside the interpret loop."

	instructionPointer _ self cCoerce: localIP to: 'int'.
	stackPointer _ self cCoerce: localSP to: 'int'.
