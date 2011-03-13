booleanPhraseFromPhrase: phrase

	| outerPhrase |
	outerPhrase _ super booleanPhraseFromPhrase: phrase.
	outerPhrase replacePlayerInReadoutWith: scriptedPlayer.
	^ outerPhrase.
