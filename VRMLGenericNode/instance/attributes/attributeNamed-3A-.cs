attributeNamed: aString
	| attr |
	attr _ self nodeSpec attributeNamed: aString.
	attr == nil ifTrue:[^nil].
	^self attributes at: attr ifAbsent:[attr].