line: pt1 to: pt2 width: w color: c
	| offset |
	offset _ origin - (w // 2) asPoint.
	port sourceForm: nil;
		fillColor: (self drawColor: c);
		combinationRule: (self drawRule: Form over);
		width: w; height: w;
		drawFrom: (pt1 + offset) to: (pt2 + offset)