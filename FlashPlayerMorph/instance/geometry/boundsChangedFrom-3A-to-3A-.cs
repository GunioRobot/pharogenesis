boundsChangedFrom: oldBounds to: newBounds
	| newWidth newLeft |
	newWidth _ localBounds width * newBounds height // localBounds height.
	newLeft _ newBounds left + (newBounds width - newWidth // 2).
	transform _ MatrixTransform2x3
		transformFromLocal: localBounds
		toGlobal: (newLeft @ newBounds top extent: newWidth @ newBounds height).