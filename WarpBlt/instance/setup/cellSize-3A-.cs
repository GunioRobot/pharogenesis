cellSize: s
	cellSize _ s.
	cellSize = 1 ifTrue: [^ self].
	colorMap _ Color colorMapIfNeededFrom: 32 to: destForm depth.
