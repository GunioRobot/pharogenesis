mouseMoveLine: newEvent
	self restoreTexture.
	currentCanvas line: lastPosition to: currentPosition width: currentNib extent x color: currentColor

