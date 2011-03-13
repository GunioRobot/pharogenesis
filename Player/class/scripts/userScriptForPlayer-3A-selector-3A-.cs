userScriptForPlayer: aPlayer selector: aSelector
	|  entry |
	scripts ifNil: [scripts _ IdentityDictionary new].
	entry _ scripts at: aSelector ifAbsent: [nil].
	entry ifNil:
		[entry _ UserScript new player: aPlayer selector: aSelector.
		scripts at: aSelector put: entry].
	^ entry