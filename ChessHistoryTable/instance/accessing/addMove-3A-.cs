addMove: aMove
	| index |
	index _ (aMove sourceSquare bitShift: 6) + aMove destinationSquare.
	self at: index put: (self at: index + 1)