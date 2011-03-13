nextSignedBits: n put: someValue
	"Write the next n bits as signed integer value"
	| value |
	value := someValue rounded. "Do rounding here if not done before"
	value < 0
		ifTrue:[self nextBits: n put: 16r100000000 - value]
		ifFalse:[self nextBits: n put: value]