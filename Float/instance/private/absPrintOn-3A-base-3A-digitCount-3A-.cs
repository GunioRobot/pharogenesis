absPrintOn: aStream base: base digitCount: digitCount 
	"Print me in the given base, using digitCount significant figures."
	| fuzz x exp q i fBase |
	fBase _ base asFloat.
	"x is myself normalized to [1.0, fBase), exp is my exponent"
	exp _ 
		self < 1.0
			ifTrue: [(fBase / self floorLog: fBase) negated]
			ifFalse: [self floorLog: fBase].
	x _ self / (fBase raisedTo: exp).
	fuzz _ fBase raisedTo: 1 - digitCount.
	"round the last digit to be printed"
	x _ 0.5 * fuzz + x.
	x >= fBase
		ifTrue: 
			["check if rounding has unnormalized x"
			x _ x / fBase.
			exp _ exp + 1].
	(exp < 6 and: [exp > -4])
		ifTrue: 
			["decimal notation"
			q _ 0.
			exp < 0 ifTrue: [1 to: 1 - exp do: [:i | aStream nextPut: ('0.0000' at: i)]]]
		ifFalse: 
			["scientific notation"
			q _ exp.
			exp _ 0].
	[x >= fuzz]
		whileTrue: 
			["use fuzz to track significance"
			i _ x asInteger.
			aStream nextPut: (Character digitValue: i).
			x _ x - i * fBase.
			fuzz _ fuzz * fBase.
			exp _ exp - 1.
			exp = -1 ifTrue: [aStream nextPut: $.]].
	[exp >= -1]
		whileTrue: 
			[aStream nextPut: $0.
			exp _ exp - 1.
			exp = -1 ifTrue: [aStream nextPut: $.]].
	q ~= 0
		ifTrue: 
			[aStream nextPut: $e.
			q printOn: aStream]