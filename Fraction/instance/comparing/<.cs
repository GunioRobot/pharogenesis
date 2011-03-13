< aNumber
	aNumber isFraction
		ifTrue: [^ numerator * aNumber denominator < (aNumber numerator * denominator)]
		ifFalse: [^ (aNumber adaptFraction: self)
					< aNumber adaptToFraction]