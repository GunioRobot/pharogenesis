emitCVariablesOn: aStream
	"Store the global variable declarations on the given stream."

	aStream nextPutAll: '/*** Variables ***/'; cr.
	variables asSortedCollection do: [ :var |
		(variableDeclarations includesKey: var) ifTrue: [
			aStream nextPutAll: (variableDeclarations at: var), ';'; cr.
		] ifFalse: [
			"default variable declaration"
			aStream nextPutAll: 'int ', var, ';'; cr.
		].
	].
	aStream cr.