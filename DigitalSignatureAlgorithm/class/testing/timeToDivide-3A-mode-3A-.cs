timeToDivide: iterationCount mode: mode
	"Exercise the divide primitive on iterationCount pairs of random 60 bit integers."
	"DigitalSignatureAlgorithm timeToDivide: 100000 mode: 1"

	| dsa r c d tmp |
	dsa _ DigitalSignatureAlgorithm new.
	r _ Random new.
		c _ ((r next * 16r3FFFFFFF highBit) asInteger bitShift: 30) +
			 (r next * 16r3FFFFFFF) asInteger.
		d _ ((r next * 16r3FFFFFFF) asInteger bitShift: 30) +
			 (r next * 16r3FFFFFFF) asInteger.
		c < d ifTrue: [tmp _ c. c _ d. d _ tmp].
	^self time: [
		iterationCount timesRepeat: [
			mode = 1 ifTrue: [dsa divide: c by: d].
			mode = 2 ifTrue: [c // d. c \\ d].
			mode = 3 ifTrue: [(c digitDiv: d neg: false) second].
		].
	] as: 'divide' count: iterationCount
