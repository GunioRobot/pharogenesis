line: pt1 to: pt2 brushForm: brush
	| offset |
	offset _ origin.
	port sourceForm: brush; fillColor: nil;
		combinationRule: (self drawRule: Form paint);
		sourceRect: brush boundingBox;
		colorMap: (brush colormapIfNeededForDepth: self depth);
		drawFrom: (pt1 + offset) to: (pt2 + offset)