sample
	"The closest we can come to an object for our type"

	| ty clsName |
	self defaultValue ifNotNil: [^ self defaultValue].
	ty _ self variableType.
	"How translate a type like #player into a class?"
	clsName _ ty asString.
	clsName at: 1 put: (clsName first asUppercase).
	clsName _ clsName asSymbol.
	(Smalltalk includesKey: clsName) ifFalse: [self error: 'What type is this?'. ^ 5].
	^ (Smalltalk at: clsName) initializedInstance