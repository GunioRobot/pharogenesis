referencePositionInWorld: aPoint
	| localPosition |
	localPosition _ owner
		ifNil: [aPoint]
		ifNotNil: [(owner transformFrom: self world) globalPointToLocal: aPoint].

	self referencePosition: localPosition
