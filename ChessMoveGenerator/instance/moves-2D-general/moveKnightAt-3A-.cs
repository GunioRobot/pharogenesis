moveKnightAt: square
	| capture moves destSquare |
	moves _ KnightMoves at: square.
	1 to: moves size do:[:i|
		destSquare _ moves at: i.
		(myPieces at: destSquare) = 0 ifTrue:[
			capture _ itsPieces at: destSquare.
			(forceCaptures and:[capture = 0]) ifFalse:[
				(moveList at: (lastMoveIndex _ lastMoveIndex + 1))
					move: Knight from: square to: destSquare capture: capture.
				capture = King ifTrue:[kingAttack _ (moveList at: lastMoveIndex)].
			].
		].
	].