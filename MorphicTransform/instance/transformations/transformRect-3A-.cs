transformRect: aRectangle
	^ (self transform: aRectangle topLeft) corner: (self transform: aRectangle bottomRight)