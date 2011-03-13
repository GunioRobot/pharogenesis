lock
	"Refer to the comment in view|lock.  Must do at least what display would do to lock the view."

	(self isUnlocked and: [self clippingBox ~= list clippingRectangle])
		ifTrue:  "Recompose the list if the window changed"
			[self positionList].
	super lock