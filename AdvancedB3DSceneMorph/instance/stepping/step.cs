step
	self isRotating ifTrue: [
		scene defaultCamera rotateBy: self rotationAngle.
		self updateHeadlight.
		self changed.].