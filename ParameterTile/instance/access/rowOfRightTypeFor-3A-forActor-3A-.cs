rowOfRightTypeFor: aLayoutMorph forActor: aPlayer
	"Answer a phrase of the right type for the putative container"

	| aTemporaryViewer aPhrase |
	aLayoutMorph demandsBoolean ifTrue:
		[aTemporaryViewer _ CategoryViewer new invisiblySetPlayer: aPlayer.
		aPhrase _ aTemporaryViewer booleanPhraseFromPhrase: self.
		aPhrase justGrabbedFromViewer: false.
		^ aPhrase].
	^ self