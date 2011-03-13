/ aFraction

	(aFraction isMemberOf: Fraction)
		ifTrue: [^self * aFraction 
	"Refer to the comment in Number|/." reciprocal]
		ifFalse: [^self retry: #/ coercing: aFraction]