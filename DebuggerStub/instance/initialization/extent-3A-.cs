extent: newExtent
	| inner |
	super extent: newExtent.
	inner _ self innerBounds.
	shortStackPane bounds: (inner topLeft + (1@(self labelHeight+1)) corner: inner bottomRight - 1)