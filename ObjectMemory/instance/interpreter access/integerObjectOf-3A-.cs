integerObjectOf: value
	value < 0
		ifTrue: [^ ((16r80000000 + value) << 1) + 1]
		ifFalse: [^ (value << 1) + 1]