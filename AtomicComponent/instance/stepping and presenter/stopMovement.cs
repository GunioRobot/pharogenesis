stopMovement
	self stopStepping.
	isMoving _ false.
	futurePosition _ nil.
	self owner checkIsCompleted