chooseClickTarget
	Cursor crossHair showWhile:
		[Sensor waitButton].
	Cursor down showWhile:
		[Sensor anyButtonPressed].
	^ (self morphsAt: (Sensor cursorPoint - self viewBox topLeft)) first