rotateAntiClockWise

	self running ifFalse: [^ self].
	currentBlock moveDeltaX: 0 deltaY: 0 deltaAngle: -1.
