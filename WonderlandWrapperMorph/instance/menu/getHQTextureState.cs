getHQTextureState
	| tex |
	tex _ myActor getTexturePointer.
	(tex isMorph and:[(tex valueOfProperty: #highQualityTexture) == true])
		ifTrue:[^'disable high quality texture']
		ifFalse:[^'enable high quality texture']