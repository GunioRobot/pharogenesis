drawOnFills: aRectangle
	^ (bounds containsRect: aRectangle) and: [color isTransparent not]