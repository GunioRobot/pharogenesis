debugDrawLine: line1 with: line2 color: aColor
	Display getCanvas
		line: (line1 start * self debugScale)
		to: (line1 end * self debugScale)
		width: 3
		color: aColor.
	Display getCanvas
		line: (line2 start * self debugScale)
		to: (line2 end * self debugScale)
		width: 3
		color: aColor.
	self debugWait.