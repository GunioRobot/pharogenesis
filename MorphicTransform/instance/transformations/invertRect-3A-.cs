invertRect: aRectangle
	^ (self invert: aRectangle topLeft) corner: (self invert: aRectangle bottomRight)