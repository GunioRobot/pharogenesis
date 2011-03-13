areasRemainingToFill: aRectangle
	^(myCamera drawSceneBackground or:[self bgCacheValid])
		ifTrue:[aRectangle areasOutside: self bounds]
		ifFalse:[Array with: aRectangle]