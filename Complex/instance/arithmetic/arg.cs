arg
	"Answer the argument of the receiver."

	self isZero ifTrue: [self error: 'zero has no argument.'].
	0 < real ifTrue: [^ (imaginary / real) arcTan].
	0 = real ifTrue:
		[0 < imaginary
			ifTrue: [^ Float pi / 2]
			ifFalse: [^ (Float pi / 2) negated]].
	real < 0 ifTrue:
		[0 <= imaginary
			ifTrue: [^ (imaginary / real) arcTan + Float pi]
			ifFalse: [^ (imaginary / real) arcTan - Float pi]]