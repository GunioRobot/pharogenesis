isLegalInstVarName: aString
	"Answer whether aString is a legal instance variable name."

	^ ((Scanner isLiteralSymbol: aString) and: [(aString includes: $:) not]) and:
		[(self inviolateInstanceVariableNames includes:  aString) not]