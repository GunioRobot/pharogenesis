fill: evt

	| state fillPt |
	(drawState includesKey: evt hand) ifFalse: [self createDrawStateFor: evt hand].
	state _ drawState at: evt hand.

	Cursor blank show.
	Cursor crossHair showWhile:
		[fillPt _ Sensor waitButton - self world viewBox origin - self position].
	originalForm shapeFill: (state at: PenColorIndex) interiorPoint: fillPt.
	self changed.
