containsAttribute: nameString ofType: typeString
	| attr |
	attr := self attributeNamed: nameString.
	^attr isNil
		ifTrue:[false]
		ifFalse:[attr type = typeString]