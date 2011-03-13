reinstallMorphicWorldAfterError

	self flag: #bob.	
	Smalltalk isMorphic ifTrue:
		[World install "To init hand events and redisplay world"].
