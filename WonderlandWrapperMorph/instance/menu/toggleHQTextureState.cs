toggleHQTextureState
	| tex |
	tex _ myActor getTexturePointer.
	tex isMorph ifFalse:[^self].
	(tex valueOfProperty: #highQualityTexture) == true
		ifTrue:[tex setProperty: #highQualityTexture toValue: false]
		ifFalse:[tex setProperty: #highQualityTexture toValue: true].
	tex changed.