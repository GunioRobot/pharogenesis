debugDraw
	| scale ofs |
	scale _ 100.
	ofs _ 400.
	self edgesDo:[:e|
		Display getCanvas line: e origin * scale + ofs to: e destination * scale + ofs width: 3 color: e classificationColor].