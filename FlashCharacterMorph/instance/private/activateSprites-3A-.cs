activateSprites: aBool
	submorphs do:[:m|
		(m isFlashMorph and:[m isFlashSprite]) ifTrue:[
			aBool 
				ifTrue:[m startPlaying]
				ifFalse:[m stopPlaying].
		].
	].