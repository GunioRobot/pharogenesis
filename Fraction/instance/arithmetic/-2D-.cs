- aFraction

	(aFraction isMemberOf: Fraction)
		ifTrue: [^self + aFraction 
	"Refer to the comment in Number|-." negated]
		ifFalse: [^self retry: #- coercing: aFraction]