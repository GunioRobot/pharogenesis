emitCVariablesOn: aStream 
	"Store the global variable declarations on the given stream."
	| varString |
	aStream nextPutAll: '/*** Variables ***/';
		 cr.
	variables asSortedCollection
		do: [:var | 
			varString _ var asString.
			self isGeneratingPluginCode
				ifTrue: [varString = 'interpreterProxy'
						ifTrue: ["quite special..."
							aStream cr; nextPutAll: '#ifdef SQUEAK_BUILTIN_PLUGIN'.
							aStream cr; nextPutAll: 'extern'.
							aStream cr; nextPutAll: '#endif'; cr]
						ifFalse: [aStream nextPutAll: 'static ']].
			(variableDeclarations includesKey: varString)
				ifTrue: [aStream nextPutAll: (variableDeclarations at: varString) , ';'; cr]
				ifFalse: ["default variable declaration"
					aStream nextPutAll: 'int ' , varString , ';'; cr]].
	aStream cr