toggleTextureAdjust
	(myActor getProperty: #adjustToTexture) == true
		ifTrue:[myActor setProperty: #adjustToTexture toValue: false]
		ifFalse:[myActor setProperty: #adjustToTexture toValue: true]