debugDrawBezier: line
	| canvas p1 p2 p3 |
	self assert:(self isBezier: line).
	p1 _ (self edgeXValueOf: line) @ (self edgeYValueOf: line) // self aaLevelGet.
	p2 _ (self bezierViaXOf: line) @ (self bezierViaYOf: line) // self aaLevelGet.
	p3 _ (self bezierEndXOf: line) @ (self bezierEndYOf: line) // self aaLevelGet.
	canvas _ Display getCanvas.
	canvas
		line: p1 to: p2 width: 2 color: Color blue;
		line: p2 to: p3 width: 2 color: Color blue.