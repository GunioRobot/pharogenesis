/ aNumber
	"Answer the result of dividing the receiver by aNumber."
	aNumber isFraction
		ifTrue: [^self * aNumber reciprocal]
		ifFalse: [^ (aNumber adaptFraction: self) / aNumber adaptToFraction]