mouseDown: evt

	oldColor := self fillStyle.
	self label: labelDown.
	self doButtonDownAction.

