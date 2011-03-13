setRotationCenter
	| p |
	self world displayWorld.
	Cursor crossHair showWhile:
		[p _ Sensor waitButton].
	Sensor waitNoButton.
	self setRotationCenterFrom: (self transformFromWorld globalPointToLocal: p).

