mouseDown: evt in: aMorph

	aMorph setProperty: #mouseDownPoint toValue: evt cursorPoint.
