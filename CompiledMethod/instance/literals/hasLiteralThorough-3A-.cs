hasLiteralThorough: literal
	"Answer true if any literal in this method is literal,
	even if embedded in array structure."

	| lit |
	2 to: self numLiterals + 1 do: 
		[:index | 
		(lit _ self objectAt: index) == literal ifTrue: [^ true].
		(lit class == Array and: [lit hasLiteral: literal]) ifTrue: [^ true]].
	^ false