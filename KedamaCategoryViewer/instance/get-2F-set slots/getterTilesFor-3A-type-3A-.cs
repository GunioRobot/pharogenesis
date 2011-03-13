getterTilesFor: getterSelector type: aType

	| phrase |
	phrase _ super getterTilesFor: getterSelector type: aType.
	phrase replacePlayerInReadoutWith: scriptedPlayer.
	^ phrase.
