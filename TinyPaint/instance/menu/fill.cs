fill

	| fillPt |
	Cursor blank show.
	Cursor crossHair showWhile:
		[fillPt _ Sensor waitButton - self world viewBox origin - self position].
	originalForm shapeFill: brushColor interiorPoint: fillPt.
	self changed.
