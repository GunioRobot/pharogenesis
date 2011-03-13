mouseDown: evt

	lastMouse _ evt cursorPoint.
	brush drawFrom: lastMouse - bounds origin to: lastMouse - bounds origin.
	self invalidRect:
		((lastMouse - brush sourceForm extent) corner:
		 (lastMouse + brush sourceForm extent)).
