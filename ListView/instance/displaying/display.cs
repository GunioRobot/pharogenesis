display 
	"Refer to the comment in View.display."
	(self isUnlocked and: [self clippingBox ~= list clippingRectangle])
		ifTrue:  "Recompose the list if the window changed"
			[selection isNil ifTrue: [selection := 0].
			self positionList].
	super display