rowOfRightTypeFor: aLayoutMorph forActor: aPlayer
	| aPartsViewer aPhrase |
	aLayoutMorph demandsBoolean ifTrue:
		[self isBoolean ifTrue: [^ self].
		aPartsViewer _ PartsViewer new invisiblySetPlayer: aPlayer.
		aPhrase _ aPartsViewer booleanPhraseFromPhrase: self.
		aLayoutMorph presenter coloredTilesEnabled ifFalse: [aPhrase makeAllTilesGreen].
		^ aPhrase].
	^ self