initialize
	super initialize.
	trackPointer _ true.
	magnification _ 2.
	color _ Color black.
	borderWidth _ 1.
	lastPos _ self sourcePoint.
	self extent: 128@128.

