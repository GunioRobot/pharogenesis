release
	"Write crc and the number of bytes encoded"
	super release.
	self updateCrc.
	crc _ crc bitXor: 16rFFFFFFFF.
	encoder flushBits.
	0 to: 3 do:[:i| encoder nextBytePut: (crc >> (i*8) bitAnd: 255)].
	0 to: 3 do:[:i| encoder nextBytePut: (bytesWritten >> (i*8) bitAnd: 255)].