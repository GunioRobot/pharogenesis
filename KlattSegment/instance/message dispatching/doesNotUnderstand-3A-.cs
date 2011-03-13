doesNotUnderstand: aMessage
	| sel |
	(parameters includesKey: (sel := (aMessage selector copyWith: $:) asSymbol))
		ifTrue: [^ parameters at: sel].
	^ super doesNotUnderstand: aMessage