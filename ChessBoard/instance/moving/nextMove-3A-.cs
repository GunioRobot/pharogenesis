nextMove: aMove 
	activePlayer applyMove: aMove.
	userAgent 
		ifNotNil: [userAgent completedMove: aMove white: activePlayer isWhitePlayer].
	activePlayer := activePlayer == whitePlayer 
				ifTrue: [blackPlayer]
				ifFalse: [whitePlayer].
	activePlayer prepareNextMove 