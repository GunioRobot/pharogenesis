pointsMessage
	| message |
	message _ 'Record: ' , currentMap record asString.
	message _ message , '   Moves: ' , mapMoves asString.
	currentMap mapStyle
		isSmallScreen ifFalse: [message _ message , '   Total: ' , gameMoves asString].
	^ message