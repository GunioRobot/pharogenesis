flushBits
	"Flush the bit buffer for future bit writing operations."
	bitPosition = 0 ifFalse:[self nextByteForBitsPut: bitBuffer].
	bitPosition := 0.
	bitBuffer := 0.