doesNotUnderstand: aMessage
	| sel |
	(parameters includesKey: (sel _ (aMessage selector copyWith: $:) asSymbol))
		ifTrue: [^ parameters at: sel].
	^ super doesNotUnderstand: aMessage