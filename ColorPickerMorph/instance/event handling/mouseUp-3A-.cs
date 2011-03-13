mouseUp: evt

	self stopStepping.
	sourceHand := nil.
	deleteOnMouseUp ifTrue: [self delete].
	self updateTargetColor.
