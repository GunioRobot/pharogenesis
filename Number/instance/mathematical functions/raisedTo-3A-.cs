raisedTo: aNumber 
	"Answer the receiver raised to aNumber."

	aNumber isInteger ifTrue:
		["Do the special case of integer power"
		^ self raisedToInteger: aNumber].
	self < 0 ifTrue:
		[ self error: self printString, ' raised to a non-integer power' ].
	aNumber = 0 ifTrue: [^ 1].		"Special case of exponent=0"
	(self = 0) | (aNumber = 1) ifTrue:
		[^ self].						"Special case of exponent=1"
	^ (aNumber * self ln) exp		"Otherwise use logarithms"