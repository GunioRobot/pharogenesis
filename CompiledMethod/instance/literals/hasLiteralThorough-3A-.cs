hasLiteralThorough: aLiteral
	"Answer true if any literal in this method is literal, even if embedded in array structure or within its pragmas."

	| literal |
	self pragmas do: [ :pragma |
		(pragma hasLiteral: aLiteral) ifTrue: [ ^ true ] ].
	2 to: self numLiterals + 1 do: [ :index | 
		literal := self objectAt: index.
		literal == aLiteral  ifTrue: [ ^ true ].
		(literal hasLiteralThorough: aLiteral) ifTrue: [ ^ true ] ].
	^ false.