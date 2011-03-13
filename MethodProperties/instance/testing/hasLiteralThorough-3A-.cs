hasLiteralThorough: literal
	"Answer true if any literal in this method is literal,
	even if embedded in array structure."
	properties ifNil:[^false].
	properties keysAndValuesDo: [:key :value |
		key == literal ifTrue: [^true].
		value == literal ifTrue:[^true].
		(value class == Array and: [value hasLiteral: literal]) ifTrue: [^ true]].
	^false