moveKingAt: square
	myPlayer isWhitePlayer
		ifTrue:[^self moveWhiteKingAt: square]
		ifFalse:[^self moveBlackKingAt: square]