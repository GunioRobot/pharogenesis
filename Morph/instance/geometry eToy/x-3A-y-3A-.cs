x: xCoord y: yCoord
	| aWorld xyOffset delta aPlayfield |
	(aWorld _ self world) ifNil: [^ self position: xCoord @ yCoord].
	xyOffset _ self topLeft - self referencePosition.
	delta _ (aPlayfield _ self referencePlayfield)
		ifNil:
			[xCoord @ (aWorld bottom - yCoord)]
		ifNotNil:
			[aPlayfield cartesianOrigin + (xCoord @ (yCoord negated))].
	self position: (xyOffset + delta)
