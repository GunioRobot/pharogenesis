doDrag: evt with: dragHandle

	target setConstrainedPositionFrom: evt cursorPoint - positionOffset.
