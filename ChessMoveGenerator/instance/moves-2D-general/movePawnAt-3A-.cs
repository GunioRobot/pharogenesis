movePawnAt: square
	"Pawns only move in one direction so check for which direction to use"
	myPlayer isWhitePlayer
		ifTrue:[^self moveWhitePawnAt: square]
		ifFalse:[^self moveBlackPawnAt: square]