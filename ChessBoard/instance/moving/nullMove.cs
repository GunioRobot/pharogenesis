nullMove
	activePlayer := activePlayer == whitePlayer 
				ifTrue: [blackPlayer]
				ifFalse: [whitePlayer]. 
	activePlayer prepareNextMove