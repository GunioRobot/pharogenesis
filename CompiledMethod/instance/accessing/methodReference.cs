methodReference
	| who |
	who _ self who.
	who = #(unknown unknown) ifTrue: [ ^nil ].
	^MethodReference new setStandardClass: who first methodSymbol: who second.
	