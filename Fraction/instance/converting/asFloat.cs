asFloat
	"Answer a Float that represents the same value as does the receiver."

	| df scaleFactor scaledDenominator |
	df _ denominator asFloat.
	^ df isInfinite
		ifTrue:
			["might be representable as a denormalized Float"
			scaleFactor _ 2 raisedToInteger: 53.
			scaledDenominator _ (denominator / scaleFactor) rounded.
			numerator asFloat / scaleFactor asFloat / scaledDenominator asFloat]
		ifFalse:
			[numerator asFloat / df]