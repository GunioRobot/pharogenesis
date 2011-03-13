initialize

	super initialize.
	self beSmoothCurve.

	random _ Random new.
	sneaky _ random next < 0.75.
	self initializeColor.
	self initializeBlobShape.
	self setVelocity