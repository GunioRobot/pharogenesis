raisedTo: aNumber
	"Answer the receiver raised to aNumber."

	aNumber isInteger ifTrue:
		["Do the special case of integer power"
		^ self raisedToInteger: aNumber].
	self < 0.0 ifTrue:
		[ ArithmeticError signal: ' raised to a non-integer power' ].
	0.0 = aNumber ifTrue: [^ 1.0].				"special case for exponent = 0.0"
	(self= 0.0) | (aNumber = 1.0) ifTrue: [^ self].	"special case for self = 1.0"
	^ (self ln * aNumber asFloat) exp			"otherwise use logarithms"
