refersToLiteral: literal 
	"Answer true if literal is identical to any literal in this array, even if imbedded in further array structures or closure methods"
	1 
		to: self size
		do: 
			[ :index | 
			| lit |
			(lit := self at: index) == literal ifTrue: [ ^ true ].
			(lit refersToLiteral: literal) ifTrue: [ ^ true ] ].
	^ false