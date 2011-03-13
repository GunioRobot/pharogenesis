mouseUp: evt

	| c |
	self stopStepping.
	sourceHand _ nil.
	deleteOnMouseUp ifTrue: [self delete].
	c _ self getColorFromKedamaWorldIfPossible: evt cursorPoint.
	c ifNotNil: [selectedColor _ c].
	self updateTargetColor.
