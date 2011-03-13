currentlyViewing: aPlayer
	^ (currentPalette notNil and: [(currentPalette isKindOf: PartsViewer) and:
		[currentPalette scriptedPlayer == aPlayer]])