computeNextToEndPoints

	| pointAfterFirst pointBeforeLast |
	pointAfterFirst _ nil.
	self lineSegmentsDo:
		[:p1 :p2 | pointAfterFirst == nil ifTrue: [pointAfterFirst _ p2 asIntegerPoint].
		pointBeforeLast _ p1 asIntegerPoint].
	curveState at: 2 put: pointAfterFirst.
	curveState at: 3 put: pointBeforeLast.
