+ aNumber
	"Answer the sum of the receiver and aNumber."
	| commonDenominator newNumerator |
	aNumber isFraction
		ifTrue: 
			[denominator = aNumber denominator ifTrue: [
				^ (Fraction 
					numerator: numerator + aNumber numerator
					denominator: denominator) reduced].
			commonDenominator _ denominator lcm: aNumber denominator.
			newNumerator _
				(numerator * (commonDenominator / denominator)) +
				(aNumber numerator * (commonDenominator / aNumber denominator)).
			^ (Fraction 
				numerator: newNumerator 
				denominator: commonDenominator) reduced]
		ifFalse: [^ (aNumber adaptFraction: self) + aNumber adaptToFraction]