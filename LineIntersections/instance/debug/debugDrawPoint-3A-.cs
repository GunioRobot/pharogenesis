debugDrawPoint: pt
	Display getCanvas
		fillRectangle: (pt * self debugScale - 3 extent: 6@6) truncated color: Color red.
	self debugWait.