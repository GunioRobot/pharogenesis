initializeFor: aPlayer
	| aNewDictionary |
	owningPlayer _ aPlayer.
	instantiatedUserScriptsDictionary ifNil: [^ self].
	aNewDictionary _ IdentityDictionary new.
	instantiatedUserScriptsDictionary associationsDo: 
		[:assoc |
			aNewDictionary at: assoc key put: (assoc value shallowCopy player: aPlayer)].
	instantiatedUserScriptsDictionary _ aNewDictionary.