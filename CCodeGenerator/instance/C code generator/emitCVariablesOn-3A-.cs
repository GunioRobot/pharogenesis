emitCVariablesOn: aStream
	"Store the global variable declarations on the given stream."
	| varString |
	aStream nextPutAll: '/*** Variables ***/'; cr.
	variables asSortedCollection do: [ :var |
		(self isGeneratingPluginCode and:[self isTranslatingLocally])
			ifTrue:[aStream nextPutAll:'static '].
		varString _ var asString.
		(variableDeclarations includesKey: varString) ifTrue: [
			aStream nextPutAll: (variableDeclarations at: varString), ';'; cr.
		] ifFalse: [
			"default variable declaration"
			aStream nextPutAll: 'int ', varString, ';'; cr.
		].
	].
	aStream cr.