nextTurn

	(self testDone: (teams at: whoseMove) for: whoseMove) ifTrue:
		[(self pieceAt: self turnIndicatorLoc) extent: self width asPoint//6; borderWidth: 2.
		^ whoseMove _ 0.  "Game over."].	

	[whoseMove _ whoseMove\\6 + 1.
	(teams at: whoseMove) isEmpty]  "Turn passes to the next player"
		whileTrue: [].
	(self pieceAt: self turnIndicatorLoc) color: (colors at: whoseMove+1)