acceptDroppingMorph: aPiece event: evt

	| dropLoc |
	super acceptDroppingMorph: aPiece event: evt.
	dropLoc _ self boardLocAt: evt cursorPoint.
	dropLoc = aPiece boardLoc ifTrue:  "Null move"
		[^ evt hand rejectDropMorph: aPiece event: evt].
	(plannedMove _ (self allMovesFrom: aPiece boardLoc)
				detect: [:move | move last = dropLoc]
				ifNone: [nil])
		ifNil: [^ evt hand rejectDropMorph: aPiece event: evt.   "Not a valid move"].

	movePhase _ 1.  "Start the animation if any."
