isTokenExternalFunctionCallingConvention
	| descriptorClass |
	descriptorClass := Smalltalk at: #ExternalFunction ifAbsent: [nil].
	descriptorClass == nil ifTrue: [^false].
	^(descriptorClass callingConventionFor: currentToken) notNil