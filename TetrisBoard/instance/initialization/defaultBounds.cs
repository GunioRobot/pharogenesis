defaultBounds
"answer the default bounds for the receiver"
	^ 0 @ 0 extent: self numColumns @ self numRows * self cellSize + (1 @ 1)