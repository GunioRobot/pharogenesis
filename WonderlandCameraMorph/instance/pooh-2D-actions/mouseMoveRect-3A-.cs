mouseMoveRect: newEvent
	| rect |
	self restoreTexture.
	rect _ Rectangle encompassing: { lastPosition. currentPosition }.
	currentCanvas frameAndFillRectangle: rect fillColor: currentColor borderWidth: currentNib extent x borderColor: Color black

