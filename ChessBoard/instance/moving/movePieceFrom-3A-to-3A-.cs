movePieceFrom: sourceSquare to: destSquare
	| move |
	searchAgent isThinking ifTrue:[^self].
	move _ (activePlayer findPossibleMovesAt: sourceSquare) contents
		detect:[:any| any destinationSquare = destSquare].
	self nextMove: move.
	searchAgent activePlayer: activePlayer.