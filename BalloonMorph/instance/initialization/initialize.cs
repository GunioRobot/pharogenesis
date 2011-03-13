initialize
	super initialize.
	self beSmoothCurve.
	color _ self class balloonColor.
	borderColor _ Color black.
	borderWidth _ 1.
	offsetFromTarget _ 0@0