generateRandomBitsOfLength: aNumberOfBits
| target |
	target _ 0.
	aNumberOfBits isZero ifTrue: [^target].
	target _ self generateOneOrZero.
	(aNumberOfBits - 1)  timesRepeat:
		[target _ (target bitShift: 1)  bitOr: self generateOneOrZero].
	^target