makeIntegerOrScaledInteger
	"at this point, there is no digit, nor fractionPart.
	maybe it can be a scaled decimal with fraction omitted..."
	
	neg
		ifTrue: [integerPart := integerPart negated].
	self readExponent
		ifTrue: [integerPart := integerPart
						* (base raisedTo: exponent)]
		ifFalse: [self readScale
				ifTrue: [nil.
					^ ScaledDecimal newFromNumber: integerPart scale: scale]].
	^ integerPart