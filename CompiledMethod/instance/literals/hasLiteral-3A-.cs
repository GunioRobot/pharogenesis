hasLiteral: literal 
	"Answer whether the receiver references the argument, literal."
	2 to: self numLiterals + 1 do:
		[:index |
		literal == (self objectAt: index) ifTrue: [^ true]].
	^false