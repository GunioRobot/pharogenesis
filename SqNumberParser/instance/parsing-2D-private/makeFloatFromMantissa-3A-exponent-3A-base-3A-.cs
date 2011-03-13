makeFloatFromMantissa: m exponent: k base: aRadix 
	"Convert infinite precision arithmetic into Floating point.
	This alogrithm rely on correct IEEE rounding mode
	being implemented in Integer>>asFloat and Fraction>>asFloat"

	| p |
	p := aRadix lowBit - 1.
	^k positive
		ifTrue: [(m * (((aRadix bitShift: p negated) raisedToInteger: k))) asFloat timesTwoPower: p*k]
		ifFalse: [(Fraction numerator: m denominator: (((aRadix bitShift: p negated) raisedToInteger: k negated) bitShift: p*k negated)) asFloat]