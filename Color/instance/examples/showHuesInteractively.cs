showHuesInteractively
	"Shows a palette of hues at (saturation, brightness) point determined by the mouse position. Click mouse button to exit and return the selected saturation and brightness."
	"Color new showHuesInteractively"

	| baseP p s v |
	baseP _ Sensor cursorPoint.
	[Sensor anyButtonPressed] whileFalse: [
		p _ Sensor cursorPoint.
		s _ ((p x - baseP x) + 80) asFloat / 100.0.
		v _ ((p y - baseP y) + 80) asFloat / 100.0.
		self showHuesAtSaturation: s brightness: v.
	].
	^ (s min: 1.0) @ (v min: 1.0)