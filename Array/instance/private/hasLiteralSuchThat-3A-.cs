hasLiteralSuchThat: litBlock
	"Answer true if litBlock returns true for any literal in this array, even if imbedded in further array structure.  This method is only intended for private use by CompiledMethod hasLiteralSuchThat:"
	| lit |
	1 to: self size do:
		[:index | lit _ self at: index.
		(litBlock value: lit) ifTrue: [^ true].
		(lit class == Array and: [lit hasLiteralSuchThat: litBlock]) ifTrue: [^ true]].
	^false