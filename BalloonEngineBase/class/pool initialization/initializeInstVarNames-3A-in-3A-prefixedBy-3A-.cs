initializeInstVarNames: aClass in: aDictionary prefixedBy: aString

	| token value |
	aClass instVarNames doWithIndex:[:instVarName :index|
		token _ (aString, instVarName first asUppercase asString, (instVarName copyFrom: 2 to: instVarName size),'Index') asSymbol.
		value _ index - 1.
		aDictionary declare: token from: Undeclared.
		(aDictionary associationAt: token) value: value.
	].
	token _ (aString, aClass name,'Size') asSymbol.
	aDictionary declare:  token from: Undeclared.
	(aDictionary associationAt: token) value: aClass instSize.