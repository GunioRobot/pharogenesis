drawOn: aCanvas
	| area |
	super drawOn: aCanvas.
	barSize > 0 ifTrue: [
		area _ self innerBounds.
		area _ area origin extent: barSize-2@area extent y.
		aCanvas fillRectangle: area color: Color gray]
