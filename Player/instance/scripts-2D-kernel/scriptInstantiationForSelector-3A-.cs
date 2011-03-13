scriptInstantiationForSelector: aSelector
	"Answer a script instantiation for the given selector, creating it at this time if necessary"

	|  entry scriptDict classEntry |
	scriptDict _ self actorState instantiatedUserScriptsDictionary.
	entry _ scriptDict at: aSelector ifAbsent: [nil].
	entry ifNil:
		[classEntry _ self class userScriptForPlayer: self selector: aSelector.
		entry _ ScriptInstantiation new player: self selector: aSelector status: classEntry defaultStatus.
		scriptDict at: aSelector put: entry].
	^ entry