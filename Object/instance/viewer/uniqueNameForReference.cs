uniqueNameForReference
	"Answer a nice name by which the receiver can be referred to by other objects.  At present this uses a global References dictionary to hold the database of references, but in due course this will need to acquire some locality"

	| aName nameSym stem knownClassVars |
	(References includesIdentity: self) ifTrue: [^ References keyAtValue: self].

	stem _ (self knownName ifNil: [self defaultNameStemForInstances asString]) capitalized.
	knownClassVars _ ScriptingSystem allKnownClassVariableNames.
	aName _ Utilities keyLike:  stem satisfying:
		[:jinaLake |
			nameSym _ jinaLake asSymbol.
			 ((References includesKey:  nameSym) not and:
				[(Smalltalk includesKey: nameSym) not]) and:
						[(knownClassVars includes: nameSym) not]].

	References at: (aName _ aName asSymbol) put: self.
	^ aName