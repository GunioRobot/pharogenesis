line: pt1 to: pt2 brushForm: brush
	| offset |
	offset _ origin.
	self setPaintColor: Color black.
	port sourceForm: brush; fillColor: nil;
		sourceRect: brush boundingBox;
		colorMap: (brush colormapIfNeededForDepth: self depth);
		drawFrom: (pt1 + offset) to: (pt2 + offset)