drawOn: aCanvas

	aCanvas
		fillRectangle: (bounds topLeft corner: bounds rightCenter)
		color: owner color darker.
	aCanvas
		fillRectangle: (bounds leftCenter corner: bounds bottomRight)
		color: owner color lighter.
