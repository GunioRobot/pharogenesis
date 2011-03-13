* aFraction

	(aFraction isMemberOf: Fraction)
		ifTrue: [^(Fraction 
					numerator: numerator * aFraction 
	"Refer to the comment in Number|*." numerator
					denominator: denominator * aFraction denominator)
					reduced]
		ifFalse: [^self retry: #* coercing: aFraction]