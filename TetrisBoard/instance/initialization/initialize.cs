initialize

	super initialize.
	resizeToFit _ false.
	bounds _ 0@0 extent: (self numColumns @ self numRows) * self cellSize + (1@1).
	color _ Color r: 0.8 g: 1.0 b: 1.0.
