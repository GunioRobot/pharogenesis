fixNameFrom: aString
	"Fix the name to be a valid Smalltalk name (e.g., so that we can compile it as an inst var and accessor message)"

	| aName |

	aName _ aString select: [:c | c isAlphaNumeric].

	"If the name is empty use 'unknown'"
	aName isEmpty ifTrue:[aName _ 'unknown'].

	"Make sure the first letter is lowercase"
	aName first isUppercase
		ifTrue: [aName _ (aName first asLowercase asString) ,
								(aName copyFrom: 2 to: aName size) ].

	"Make sure the first letter is a letter, otherwise use 'a' as the first letter"
	aName first isLetter ifFalse: [aName _ 'a' , aName].

	^ aName.
