setRotationCenter

	| oldRotation p oldScale |
	oldRotation _ rotationDegrees.
	oldScale _ scalePoint.
	scalePoint _ 1.0@1.0.
	self rotationDegrees: 0.0.
	self world displayWorld.
	Cursor crossHair showWhile:
		[p _ Sensor waitButton - self world viewBox origin].
	self rotationCenter: p - bounds origin.
	scalePoint _ oldScale.
	self rotationDegrees: oldRotation.
