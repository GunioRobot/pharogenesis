atRow: y
    "Answer a whole row."

	(y < 1 or: [y > self height]) ifTrue: [self errorSubscriptBounds: y].
	^ contents copyFrom: y - 1 * width + 1 to: y * width