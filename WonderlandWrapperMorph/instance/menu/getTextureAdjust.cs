getTextureAdjust
	(myActor getProperty: #adjustToTexture) == true
		ifTrue:[^'do not adjust to texture']
		ifFalse:[^'auto adjust to texture']