peekByte: offset
	"Callers beware: bytePointer is pre-incremented!"

	^self byteAt: bytePointer + offset