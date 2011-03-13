printOn: aStream
	"Append an approximated representation of the receiver on aStream.
	Use prescribed number of digits after decimal point (the scale) using a rounding operation if not exact"
	
	| fractionPart |
	scale = 0
		ifTrue: [self rounded printOn: aStream]
		ifFalse: [self integerPart printOn: aStream.
			aStream nextPut: $..
			fractionPart := (self abs fractionPart * (10 raisedToInteger: scale)) rounded.
			aStream nextPutAll: (String new: scale - (fractionPart numberOfDigitsInBase: 10) withAll: $0).
			fractionPart printOn: aStream].
	
	"Append a scale specification so that the number can be recognized as a ScaledDecimal"
	aStream nextPut: $s; print: scale.