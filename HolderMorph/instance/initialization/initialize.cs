initialize

	super initialize.
	self borderWidth: 1.
	self extent: 240@160.
	color _ Color r: 0.8 g: 1.0 b: 0.6.
	cursorColor _ Color black.
	cursor _ 1.
	padding _ 3.
	openToDragNDrop _ true.
