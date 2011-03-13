okayToDestroyScriptNamed: scriptName
	costume world allExtantPlayers do:
		[:aPlayer | (aPlayer hasScriptInvoking: scriptName ofPlayer: self)
			ifTrue:
				[^ false]].
	^ true