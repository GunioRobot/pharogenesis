line: pt1 to: pt2 width: w color: c
	| offset |
	offset _ origin - (w // 2) asPoint.
	self setFillColor: c.
	port width: w; height: w;
		drawFrom: (pt1 + offset) to: (pt2 + offset)