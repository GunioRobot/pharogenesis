fill

	| fillPt |
	Cursor blank show.
	Cursor crossHair showWhile:
		[fillPt _ Sensor waitButton - self position].
	originalForm shapeFill: brushColor interiorPoint: fillPt.
	self changed.
