extent: aPoint

	| wasDifferent |
	wasDifferent _ self extent ~= aPoint.
	super extent: aPoint.
	wasDifferent ifTrue: [self adjustSubmorphPositions].