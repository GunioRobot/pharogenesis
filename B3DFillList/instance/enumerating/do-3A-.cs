do: aBlock
	| face |
	B3DScanner doDebug ifTrue:[self validate].
	face _ firstFace.
	[face == nil] whileFalse:[
		aBlock value: face.
		face _ face nextFace.
	].