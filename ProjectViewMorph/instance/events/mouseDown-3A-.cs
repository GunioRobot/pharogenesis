mouseDown: evt
	self showBorderAs: Color red.
	self world displayWorld.
	mouseDownTime _ Time millisecondClockValue