readRemainderOf: integerPart from: aStream base: base
	"Read optional fractional part and exponent, and return the final result"
	| value fraction fracpos |
	value _ integerPart.
	(aStream peekFor: $.)
		ifTrue: 
			["<integer>.<fraction>"
			(aStream atEnd not and: [aStream peek digitValue between: 0 and: base - 1])
				ifTrue: 
					[fracpos _ aStream position.
					fraction _ Integer readFrom: aStream base: base.
					fraction _ 
						fraction asFloat / (base raisedTo: aStream position - fracpos).
					value _ value asFloat + (value < 0
									ifTrue: [fraction negated]
									ifFalse: [fraction])]
				ifFalse: 
					["oops - just <integer>."
					aStream skip: -1.		"un-gobble the period"
					^ value
					"Number readFrom: '3r-22.2'"]].
	(aStream peekFor: $e)
		ifTrue: 
			["<integer>e<exponent>"
			^ value * (base raisedTo: (Integer readFrom: aStream))].
	^ value