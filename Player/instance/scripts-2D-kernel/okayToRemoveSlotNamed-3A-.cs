okayToRemoveSlotNamed: aSlotName
	costume world allExtantPlayers do:
		[:aPlayer | (aPlayer hasScriptReferencing: aSlotName ofPlayer: self)
			ifTrue:
				[^ false]].
	^ true