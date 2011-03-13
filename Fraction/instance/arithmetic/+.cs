+ aNumber 
	"Answer the sum of the receiver and aNumber."
	| n d d1 d2 |
	aNumber isFraction
		ifTrue: 
			[d _ denominator gcd: aNumber denominator.
			n _ numerator * (d1 _ aNumber denominator // d) + (aNumber numerator * (d2 _ denominator // d)).
			d1 _ d1 * d2.
			n _ n // (d2 _ n gcd: d).
			(d _ d1 * (d // d2)) = 1 ifTrue: [^ n].
			^ Fraction numerator: n denominator: d]
		ifFalse: [^ (aNumber adaptFraction: self)
				+ aNumber adaptToFraction]