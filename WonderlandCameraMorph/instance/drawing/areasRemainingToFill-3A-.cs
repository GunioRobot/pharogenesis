areasRemainingToFill: aRectangle
	^(myCamera drawSceneBackground)
		ifTrue:[aRectangle areasOutside: self bounds]
		ifFalse:[Array with: aRectangle]