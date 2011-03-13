nextNumber
	"main method for reading a number.
	This one can read Float Integer and ScaledDecimal"
	
	| numberOfTrailingZeroInIntegerPart numberOfNonZeroFractionDigits mantissa decimalMultiplier decimalFraction value numberOfTrailingZeroInFractionPart |
	(sourceStream nextMatchAll: 'NaN')
		ifTrue: [^ Float nan].
	neg := sourceStream peekFor: $-.
	(sourceStream nextMatchAll: 'Infinity')
		ifTrue: [^ neg
				ifTrue: [Float infinity negated]
				ifFalse: [Float infinity]].
	integerPart := self nextUnsignedIntegerBase: base.
	numberOfTrailingZeroInIntegerPart := nDigits - lastNonZero.
	(sourceStream peekFor: $r)
		ifTrue: ["<base>r<integer>"
			(base := integerPart) < 2
				ifTrue: [^ self expected: 'an integer greater than 1 as valid radix'].
			(sourceStream peekFor: $-)
				ifTrue: [neg := neg not].
			integerPart := self nextUnsignedIntegerBase: base.
			numberOfTrailingZeroInIntegerPart := nDigits - lastNonZero].
	^ (sourceStream peekFor: $.)
		ifTrue: [fractionPart := self
						nextUnsignedIntegerBase: base
						ifFail: [sourceStream skip: -1.
							^ neg
								ifTrue: [integerPart negated]
								ifFalse: [integerPart]].
			numberOfNonZeroFractionDigits := lastNonZero.
			numberOfTrailingZeroInFractionPart := nDigits - lastNonZero.
			self readExponent
				ifFalse: [self readScale
						ifTrue: [decimalMultiplier := base raisedTo: numberOfNonZeroFractionDigits.
							decimalFraction := integerPart * decimalMultiplier + fractionPart / decimalMultiplier.
							neg
								ifTrue: [decimalFraction := decimalFraction negated].
							^ ScaledDecimal newFromNumber: decimalFraction scale: scale]].
			fractionPart isZero
				ifTrue: [mantissa := integerPart
								// (base raisedTo: numberOfTrailingZeroInIntegerPart).
					exponent := exponent + numberOfTrailingZeroInIntegerPart]
				ifFalse: [mantissa := integerPart
								* (base raisedTo: numberOfNonZeroFractionDigits) + (fractionPart // (base raisedTo: numberOfTrailingZeroInFractionPart)).
					exponent := exponent - numberOfNonZeroFractionDigits].
			"very naive algorithm"
			value := self makeFloatFromMantissa: mantissa exponent: exponent base: base.
			^ neg
				ifTrue: [value isZero
						ifTrue: [Float negativeZero]
						ifFalse: [value negated]]
				ifFalse: [value]]
		ifFalse: [self makeIntegerOrScaledInteger]