toggleActiveTextureState
	(myActor getProperty: #activeTexture) == true
		ifTrue:[myActor setProperty: #activeTexture toValue: false]
		ifFalse:[myActor setProperty: #activeTexture toValue: true]