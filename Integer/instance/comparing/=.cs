= aNumber
	aNumber isNumber ifFalse: [^ false].
	aNumber isInteger
		ifTrue: [aNumber negative == self negative
					ifTrue: [^ (self digitCompare: aNumber) = 0]
					ifFalse: [^ false]]
		ifFalse: [^ (aNumber adaptInteger: self) = aNumber adaptToInteger]