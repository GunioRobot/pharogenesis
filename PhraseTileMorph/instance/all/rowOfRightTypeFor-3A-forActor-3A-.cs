rowOfRightTypeFor: aLayoutMorph forActor: aPlayer
	| aTemporaryViewer aPhrase |
	aLayoutMorph demandsBoolean ifTrue:
		[self isBoolean ifTrue: [^ self].
		aTemporaryViewer _ CategoryViewer new invisiblySetPlayer: aPlayer.
		aPhrase _ aTemporaryViewer booleanPhraseFromPhrase: self.
		^ aPhrase].
	^ self