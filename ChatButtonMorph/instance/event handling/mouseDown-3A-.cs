mouseDown: evt

	oldColor _ self fillStyle.
	self label: labelDown.
	self doButtonDownAction.

