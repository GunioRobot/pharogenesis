moveRight

	self running ifFalse: [^ self].
	currentBlock moveDeltaX: 1 deltaY: 0 deltaAngle: 0.
