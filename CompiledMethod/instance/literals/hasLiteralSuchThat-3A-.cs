hasLiteralSuchThat: aBlock
	"Answer true if aBlock returns true for any literal in this method, even if imbedded in array structure or within its pragmas."
	
	| literal |
	self pragmas do: [ :pragma |
		(pragma hasLiteralSuchThat: aBlock)
			ifTrue: [ ^ true ] ].
	2 to: self numLiterals + 1 do: [ :index | 
		literal := self objectAt: index.
		(aBlock value: literal)
			ifTrue: [ ^ true ].
		(literal hasLiteralSuchThat: aBlock)
			ifTrue: [ ^ true ] ].
	^ false.