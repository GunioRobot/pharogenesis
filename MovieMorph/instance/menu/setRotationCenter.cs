setRotationCenter

	| frame p |
	frame _ self currentFrame.
	frame ifNil: [^ self].
	self rotationDegrees: 0.0.   "must set rotation center with no rotation"
	self world displayWorld.
	Cursor crossHair showWhile:
		[p _ Sensor waitButton - self world viewBox origin].
	frame rotationCenter: p - frame bounds origin.
	self setFrame: currentFrameIndex.
