step
	futurePosition = self position
		ifTrue: [self stopMovement]
		ifFalse: [self doMovement]