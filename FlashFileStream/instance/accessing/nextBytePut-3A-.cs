nextBytePut: aByte
	"Make sure the bit buffer is reset"
	self flushBits.
	stream nextPut: aByte