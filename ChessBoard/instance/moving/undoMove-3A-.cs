undoMove: aMove 
	activePlayer := activePlayer == whitePlayer 
				ifTrue: [blackPlayer]
				ifFalse: [whitePlayer]. 
	activePlayer undoMove: aMove.
	userAgent 
		ifNotNil: [userAgent undoMove: aMove white: activePlayer isWhitePlayer]