timeMultiply: iterationCount mode: mode
	"Exercise the multiply primitive on iterationCount pairs of random 60 bit integers."
	"DigitalSignatureAlgorithm timeMultiply: 100000 mode: 1"

	| dsa r x y |
	dsa _ DigitalSignatureAlgorithm new.
	r _ Random new.
		x _ ((r next * 16r3FFFFFFF highBit) asInteger bitShift: 30) +
			 (r next * 16r3FFFFFFF) asInteger.
		y _ ((r next * 16r3FFFFFFF) asInteger bitShift: 30) +
			 (r next * 16r3FFFFFFF) asInteger.
	^self time: [
		iterationCount timesRepeat: [
			mode = 1 ifTrue: [dsa multiply: x by: y].
			mode = 2 ifTrue: [x * y].
		].

	] as: 'multiply' count: iterationCount
