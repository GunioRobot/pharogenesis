scaleAndSignExtend: aNumber inFieldWidth: w

	^ aNumber < (1 << (w - 1))
		ifTrue: [aNumber + (1 << w) negated + 1]
		ifFalse: [aNumber]