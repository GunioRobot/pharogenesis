setProperty: aSymbol toValue: anObject
	anObject == nil ifTrue:["Remove property"
		myProperties ifNotNil:[^myProperties removeKey: aSymbol ifAbsent:[nil]]].
	myProperties == nil ifTrue:[myProperties _ IdentityDictionary new].
	myProperties at: aSymbol put: anObject.