debugDraw
	| canvas |
	canvas _ Display getCanvas.
	self lineSegmentsDo:[:p1 :p2|
		canvas line: p1 rounded to: p2 rounded width: 1 color: Color black.
	].