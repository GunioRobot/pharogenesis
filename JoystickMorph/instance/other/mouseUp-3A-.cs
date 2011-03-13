mouseUp: evt

	lastAngle _ self angle.
	autoCenter ifTrue: [self moveHandleToCenter].
