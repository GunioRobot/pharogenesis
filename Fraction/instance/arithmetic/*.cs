* aNumber 
	"Answer the result of multiplying the receiver by aNumber."
	| d1 d2 |
	aNumber isFraction
		ifTrue: 
			[d1 _ numerator gcd: aNumber denominator.
			d2 _ denominator gcd: aNumber numerator.
			(d2 = denominator and: [d1 = aNumber denominator])
				ifTrue: [^ numerator // d1 * (aNumber numerator // d2)].
			^ Fraction numerator: numerator // d1 * (aNumber numerator // d2) denominator: denominator // d2 * (aNumber denominator // d1)]
		ifFalse: [^ (aNumber adaptFraction: self)
				* aNumber adaptToFraction]