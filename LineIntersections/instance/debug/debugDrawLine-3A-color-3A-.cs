debugDrawLine: line color: aColor
	Display getCanvas
		line: (line start * self debugScale)
		to: (line end * self debugScale)
		width: 3
		color: aColor.
	self debugWait.