queueDict
	queueDict ifNil: [queueDict _ IdentityDictionary new].
	^ queueDict.