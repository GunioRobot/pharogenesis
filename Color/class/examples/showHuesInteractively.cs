showHuesInteractively
	"Shows a palette of hues at a (saturation, brightness) point determined by the mouse position. Click the mouse button to exit and return the selected (saturation, brightness) point."
	"Color showHuesInteractively"

	| p s v |
	[Sensor anyButtonPressed] whileFalse: [
		p _ Sensor cursorPoint.
		s _ p x asFloat / 300.0.
		v _ p y asFloat / 300.0.
		self showColors: (self wheel: 12 saturation: s brightness: v)].
	^ (s min: 1.0) @ (v min: 1.0)