nextLiteral
	"Same as advance, but -4 comes back as a number instead of two tokens"

	| prevToken |
	prevToken _ self advance.
	(prevToken == #- and: [token isKindOf: Number])
		ifTrue: 
			[^self advance negated].
	^prevToken