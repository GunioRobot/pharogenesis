setCenterOfRotation: evt with: rotationHandle

	innerTarget setRotationCenterFromGlobalPosition:
		(Sensor cursorPoint - self world viewBox origin).
	self endInteraction
