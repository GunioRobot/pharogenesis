bindVariablesIn: aDictionary

	| newNode |
	newNode _ aDictionary at: name asSymbol ifAbsent: [ ^self ].
	^newNode copyTree