initialize

	super initialize.
	self form: ColorChart deepCopy.
	selectedColor _ Color white.
	sourceHand _ nil.
	deleteOnMouseUp _ true.
	updateContinuously _ true.
	selector _ nil.
	target _ nil.
