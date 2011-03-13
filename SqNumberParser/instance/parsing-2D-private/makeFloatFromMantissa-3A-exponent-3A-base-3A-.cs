makeFloatFromMantissa: m exponent: k base: aRadix 
	"Convert infinite precision arithmetic into Floating point.
	This alogrithm rely on correct IEEE rounding mode
	being implemented in Integer>>asFloat and Fraction>>asFloat"

	^(k positive
		ifTrue: [m * (aRadix raisedTo: k)]
		ifFalse: [Fraction numerator: m denominator: (aRadix raisedTo: k negated)]) asFloat