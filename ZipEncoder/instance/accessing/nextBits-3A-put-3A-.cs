nextBits: nBits put: value
	"Store a value of nBits"
	"self assert:[value >= 0 and:[(1 bitShift: nBits) > value]]."
	bitBuffer _ bitBuffer bitOr: (value bitShift: bitPosition).
	bitPosition _ bitPosition + nBits.
	[bitPosition >= 8] whileTrue:[
		self nextBytePut: (bitBuffer bitAnd: 255).
		bitBuffer _ bitBuffer bitShift: -8.
		bitPosition _ bitPosition - 8].