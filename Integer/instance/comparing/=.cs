= arg
	arg isNumber
		ifFalse: [^ false].
	arg isInteger
		ifTrue: [arg negative == self negative
					ifTrue: [^ (self digitCompare: arg) = 0]
					ifFalse: [^ false]]
		ifFalse: [^ self retry: #= coercing: arg]