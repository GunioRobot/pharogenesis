hasLiteralSuchThat: litBlock
	"Answer true if litBlock returns true for any literal in this method, even if imbedded in array structure."
	| lit |
	2 to: self numLiterals + 1 do:
		[:index | lit _ self objectAt: index.
		(litBlock value: lit) ifTrue: [^ true].
		(lit class == Array and: [lit hasLiteralSuchThat: litBlock]) ifTrue: [^ true]].
	^false