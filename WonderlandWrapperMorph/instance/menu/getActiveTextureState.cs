getActiveTextureState
	(myActor getProperty: #activeTexture) == true
		ifTrue:[^'disable active texture']
		ifFalse:[^'enable active texture']