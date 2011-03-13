position: aPoint
	"Overridden to align submorph origins to the grid if gridding is on."
	| adjustedPosition |
	adjustedPosition := aPoint.
	temporaryCursor ifNotNil: [adjustedPosition := adjustedPosition + temporaryCursorOffset].
	^ super position: adjustedPosition
