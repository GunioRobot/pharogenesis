scriptInstantiationForSelector: aSelector
	|  entry scriptDict classEntry |
	scriptDict _ self actorState instantiatedUserScriptsDictionary.
	entry _ scriptDict at: aSelector ifAbsent: [nil].
	entry ifNil:
		[classEntry _ self class userScriptForPlayer: self selector: aSelector.
		entry _ ScriptInstantiation new player: self selector: aSelector status: classEntry status.
		entry anonymous: classEntry isAnonymous.
		scriptDict at: aSelector put: entry].
	^ entry