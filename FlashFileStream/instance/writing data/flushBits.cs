flushBits
	"Flush the bit buffer for future bit writing operations."
	bitPosition = 0 ifFalse:[self nextByteForBitsPut: bitBuffer].
	bitPosition _ 0.
	bitBuffer _ 0.