mouseDown: evt

	didMenu _ nil.
	mouseDownTime _ Time millisecondClockValue.
	super mouseDown: evt.
