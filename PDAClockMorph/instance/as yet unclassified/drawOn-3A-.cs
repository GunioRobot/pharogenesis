drawOn: aCanvas

	aCanvas frameAndFillRectangle: bounds fillColor: backgroundColor
				borderWidth: 1 borderColor: borderColor.
	super drawOn: aCanvas.
