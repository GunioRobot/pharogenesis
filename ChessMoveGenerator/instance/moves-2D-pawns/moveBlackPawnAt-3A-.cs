moveBlackPawnAt: square
	"Pawns only move in one direction so check for which direction to use"
	forceCaptures ifFalse:[self blackPawnPushAt: square].
	(square bitAnd: 7) = 1
		ifFalse:[self blackPawnCaptureAt: square direction: 1].
	(square bitAnd: 7) = 0 
		ifFalse:[self blackPawnCaptureAt: square direction: -1].
