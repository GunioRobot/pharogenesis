internalizeIPandSP
	"Copy the local instruction and stack pointer to local variables for rapid access within the interpret loop."

	self assertStackPointerIsExternal.
	localCP _ "self cCoerce:" activeCachedContext "to: 'char *'".

	localIP _ self cCoerce: self internalInstructionPointer to: 'char *'.
	localSP _ self cCoerce: self internalStackPointer to: 'char *'.
	self assertStackPointerIsInternal.

"	localTP _ self cCoerce: self internalTemporaryPointer to: 'char *'."
"	localTP _ self cCoerce: theTemporaryPointer to: 'char *'."