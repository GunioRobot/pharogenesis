drawOn: aCanvas
	| width inner |
	super drawOn: aCanvas.
	inner _ self innerBounds.
	width _ (inner width * lastValue) truncated min: inner width.
	aCanvas fillRectangle: (inner origin extent: width @ inner height) color: progressColor.