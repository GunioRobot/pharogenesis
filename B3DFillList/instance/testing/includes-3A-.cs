includes: aFace
	| face |
	face _ firstFace.
	[face == nil] whileFalse:[
		face == aFace ifTrue:[^true].
		face _ face nextFace.
	].
	^false