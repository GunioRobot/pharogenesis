readRemainderOf: integerPart from: aStream base: base withSign: sign
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
					value _ value asFloat + fraction]
				ifFalse: 
					["oops - just <integer>."
					aStream skip: -1.		"un-gobble the period"
					^ value * sign
					"Number readFrom: '3r-22.2'"]].
	(aStream peekFor: $e)
		ifTrue: 
			["<integer>e<exponent>"
			value _ value * (base raisedTo: (Integer readFrom: aStream))].
	(value isFloat and: [value = 0.0 and: [sign = -1]])
		ifTrue: [^ Float negativeZero]
		ifFalse: [^ value * sign]