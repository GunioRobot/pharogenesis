commonBase: aVersion

	| smallNums largeNums cutoff |
	(aVersion numbers size <= numbers size) 
		ifTrue: [smallNums := aVersion numbers. largeNums := numbers] 
		ifFalse: [smallNums := numbers. largeNums := aVersion numbers].

	cutoff := (1 to: smallNums size) 
		detect: [ :in | ((smallNums at: in) ~= (largeNums at: in))] 
		ifNone: [^self class fromCollection: smallNums].

	^self class fromCollection: 
		((numbers copyFrom: 1 to: (cutoff - 1)), 
		(Array with: ((smallNums at: cutoff) min: (largeNums at: cutoff))))
