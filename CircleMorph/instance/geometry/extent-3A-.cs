extent: aPoint
	| size oldRotationCenter |
	oldRotationCenter _ self rotationCenter.
	size _ aPoint x min: aPoint y.
	super extent: size @ size.
	self rotationCenter: oldRotationCenter.