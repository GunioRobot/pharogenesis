debugDrawLine: line
	| canvas |
	self assert: (self isLine: line).
	canvas _ Display getCanvas.
	canvas
		line: (self edgeXValueOf: line) @ (self edgeYValueOf: line) // self aaLevelGet
		to: (self lineEndXOf: line) @ (self lineEndYOf: line) // self aaLevelGet
		width: 2
		color: Color red.