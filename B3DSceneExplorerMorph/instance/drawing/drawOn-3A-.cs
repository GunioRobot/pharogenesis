drawOn: aCanvas
	super drawOn: aCanvas.
	aCanvas fillRectangle: (self bounds insetBy: frameWidth) color: Color black.