mouseMoveEllipse: newEvent
	| rect |
	self restoreTexture.
	rect _ Rectangle encompassing: { lastPosition. currentPosition }.
	currentCanvas fillOval: rect color: currentColor borderWidth: currentNib extent x borderColor: Color black

