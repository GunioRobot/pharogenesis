< anInteger
	(anInteger isInteger)
		ifTrue: [self negative == anInteger negative
					ifTrue: [self negative
								ifTrue: [^(self digitCompare: anInteger) > 0]
								ifFalse: [^(self digitCompare: anInteger) < 0]]
					ifFalse: [^self negative]]
		ifFalse: [^self retry: #< coercing: anInteger]