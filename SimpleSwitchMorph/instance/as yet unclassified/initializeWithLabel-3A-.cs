initializeWithLabel: labelString

	super initializeWithLabel: labelString.
	self borderWidth: 3.
	self extent: self extent + 2.
	onColor _ Color r: 1.0 g: 0.6 b: 0.6.
	offColor _ Color lightGray.
