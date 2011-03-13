hasLiteral: literal
	"Answer whether the receiver references the argument, literal."
	2 to: self numLiterals - 1 "exclude superclass + selector/properties"
	  do:[:index |
		literal == (self objectAt: index) ifTrue: [^true]].
	^false