initializeFrom: aBlock
	| last next |
	last _ nil.
	1 to: self size // 2 do:[:i|
		next _ aBlock value: (i-1) / (self size // 2 - 1) asFloat.
		(next isInfinite or:[next isNaN]) ifTrue:[next _ 0.0].
		self at: i*2-1 put: next.
		i > 1 ifTrue:[self at: i-1*2 put: next - last].
		last _ next.
	].