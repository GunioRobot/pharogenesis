initialize
	"initialize the state of the receiver"
	super initialize.
	""
	self extent: 365 @ 80.

	dataColor _ Color darkGray.
	cursor _ 1.0.
	"may be fractional"
	cursorColor _ Color red.
	cursorColorAtZeroCrossings _ Color red.
	startIndex _ 1.
	hasChanged _ false.
	self
		data: ((0 to: 360 - 1)
				collect: [:x | (100.0 * x degreesToRadians sin) asInteger])