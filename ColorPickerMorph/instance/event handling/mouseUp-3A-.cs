mouseUp: evt

	self stopStepping.
	sourceHand _ nil.
	deleteOnMouseUp ifTrue: [self delete].
	self updateTargetColor.
