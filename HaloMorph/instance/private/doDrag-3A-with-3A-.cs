doDrag: evt with: dragHandle

	target setConstrainedPositionFrom:
		(target pointFromWorld: evt cursorPoint - positionOffset).
