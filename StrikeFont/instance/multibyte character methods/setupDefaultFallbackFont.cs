setupDefaultFallbackFont

	| fonts f |
	fonts _ TextStyle default fontArray.
	f _ fonts first.
	1 to: fonts size do: [:i |
		self height > (fonts at: i) height ifTrue: [f _ fonts at: i].
	].
	self fallbackFont: f.
	self reset.

