< aNumber
	aNumber isFraction
		ifTrue: [aNumber numerator = 0
				ifTrue: [^numerator < 0]
				ifFalse: [^self - aNumber < 0]]
		ifFalse: [^ (aNumber adaptFraction: self) < aNumber adaptToFraction]