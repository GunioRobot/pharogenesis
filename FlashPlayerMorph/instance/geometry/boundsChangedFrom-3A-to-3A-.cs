boundsChangedFrom: oldBounds to: newBounds
	| newWidth newLeft |
	newWidth := localBounds width * newBounds height // localBounds height.
	newLeft := newBounds left + (newBounds width - newWidth // 2).
	transform := MatrixTransform2x3
		transformFromLocal: localBounds
		toGlobal: (newLeft @ newBounds top extent: newWidth @ newBounds height).