getActiveTexture
	^myTexture isMorph
		ifTrue:[myTexture]
		ifFalse:[nil]