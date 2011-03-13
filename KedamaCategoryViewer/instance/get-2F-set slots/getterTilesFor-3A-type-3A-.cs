getterTilesFor: getterSelector type: aType

	| phrase |
	phrase := super getterTilesFor: getterSelector type: aType.
	phrase replacePlayerInReadoutWith: scriptedPlayer.
	^ phrase.
