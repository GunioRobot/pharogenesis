flushBits
	"Flush currently unsent bits"
	[bitPosition > 0] whileTrue:[
		self nextBytePut: (bitBuffer bitAnd: 255).
		bitBuffer _ bitBuffer bitShift: -8.
		bitPosition _ bitPosition - 8].
	bitPosition _ 0.