mouseDown: evt
	lastPoint _ nil.
	points _ subdivision _ firstPoly _ nil.
	self mouseMove: evt.