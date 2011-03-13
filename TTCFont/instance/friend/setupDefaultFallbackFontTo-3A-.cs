setupDefaultFallbackFontTo: aTextStyleOrNil
"
	TTCFont allInstances do: [:i | i setupDefaultFallbackFontTo: (TextStyle named: 'MultiMSMincho')].
"

	| fonts f |
	aTextStyleOrNil ifNil: [
		self fallbackFont: nil.
		^ self.
	].
	fonts _ aTextStyleOrNil fontArray.
	(aTextStyleOrNil defaultFont familyName endsWith: self familyName) ifTrue: [fallbackFont _ nil. ^ self].

	f _ fonts first.
	1 to: fonts size do: [:i |
		self height >= (fonts at: i) height ifTrue: [f _ fonts at: i].
	].
	self fallbackFont: f.
	self reset.

