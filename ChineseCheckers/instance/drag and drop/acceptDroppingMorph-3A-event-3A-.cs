acceptDroppingMorph: aPiece event: evt

	| dropLoc |
	super acceptDroppingMorph: aPiece event: evt.
	dropLoc _ self boardLocAt: evt cursorPoint.
	dropLoc = aPiece boardLoc ifTrue:  "Null move"
		[^ aPiece rejectDropMorphEvent: evt].
	(plannedMove _ (self allMovesFrom: aPiece boardLoc)
				detect: [:move | move last = dropLoc]
				ifNone: [nil])
		ifNil: [^ aPiece rejectDropMorphEvent: evt.   "Not a valid move"].

	movePhase _ 1.  "Start the animation if any."
