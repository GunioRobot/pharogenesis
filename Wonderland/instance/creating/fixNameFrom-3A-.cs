fixNameFrom: aString
	"Fix the name to be a valid Smalltalk name (e.g., so that we can compile it as an inst var and accessor message)"

	| aName |
	aName _ aString select:[:c| c isAlphaNumeric].
	aName isEmpty ifTrue:[aName _ 'unkwown'].
	aName first isUppercase ifTrue:[aName _ aName first asLowercase asString, (aName copyFrom: 2 to: aName size)].
	aName first isLetter ifFalse:[aName _ 'a', aName].
	^aName