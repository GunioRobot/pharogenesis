initializeFor: aSketchMorph inBounds: boundsToUse pasteUpMorph: aPasteUpMorph
	| aPaintBox newPaintBoxBounds worldBounds requiredWidth newOrigin aPosition aPal aTab |
	(aTab _ self world paintingFlapTab) ifNotNil:
		[aTab showFlap.
		^ self initializeFor: aSketchMorph inBounds: boundsToUse pasteUpMorph: aPasteUpMorph paintBoxPosition: nil].

	aPaintBox _ self world paintBox.
	worldBounds _ self world bounds.
	requiredWidth _ aPaintBox width.

	aPosition _ (aPal _ aPasteUpMorph standardPalette)
		ifNotNil:
			[aPal showNoPalette.
			aPal topRight + (aPaintBox width negated @ 0 "aPal tabsMorph height")]
		ifNil:
			[boundsToUse topRight].

	newOrigin _ ((aPosition x  + requiredWidth <= worldBounds right) or: [Preferences unlimitedPaintArea])
			ifTrue:  "will fit to right of aPasteUpMorph"
				[aPosition]
			ifFalse:  "won't fit to right, try left"
				[boundsToUse topLeft - (requiredWidth @ 0)].
	newPaintBoxBounds _ (newOrigin extent: aPaintBox extent) translatedToBeWithin: worldBounds.
	

	self initializeFor: aSketchMorph inBounds: boundsToUse pasteUpMorph: aPasteUpMorph paintBoxPosition: newPaintBoxBounds origin