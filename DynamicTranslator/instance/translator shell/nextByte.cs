nextByte
	"Note: bytePointer is pre-incremented!"

	^self byteAt: (bytePointer _ bytePointer + 1)