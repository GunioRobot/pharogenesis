> aNumber
	aNumber isInteger
		ifTrue: [self negative == aNumber negative
					ifTrue: [self negative
								ifTrue: [^(self digitCompare: aNumber) < 0]
								ifFalse: [^(self digitCompare: aNumber) > 0]]
					ifFalse: [^ aNumber negative]]
		ifFalse: [^ (aNumber adaptInteger: self) > aNumber adaptToInteger]