= aNumber
	aNumber isNumber ifFalse: [^ false].
	aNumber isFraction
		ifTrue: [aNumber numerator = 0
				ifTrue: [^numerator = 0]
				ifFalse: [^aNumber numerator = numerator 
							and: [aNumber denominator = denominator]]]
		ifFalse: [^ (aNumber adaptFraction: self) = aNumber adaptToFraction]