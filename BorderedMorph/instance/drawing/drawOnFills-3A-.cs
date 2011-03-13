drawOnFills: aRectangle
	^ (bounds containsRect: aRectangle) and: [self isOpaque]