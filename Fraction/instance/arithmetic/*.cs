* aNumber
	"Answer the result of multiplying the receiver by aNumber."
	aNumber isFraction
		ifTrue: [^ (Fraction numerator: numerator * aNumber numerator
							denominator: denominator * aNumber denominator)
						reduced]
		ifFalse: [^ (aNumber adaptFraction: self) * aNumber adaptToFraction]