step
    scene isNil ifTrue: [^self].
	self isRotating ifTrue: [
		scene defaultCamera rotateBy: self rotationAngle.
		self changed.].