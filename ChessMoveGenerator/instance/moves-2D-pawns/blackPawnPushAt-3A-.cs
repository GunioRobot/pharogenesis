blackPawnPushAt: square
	| destSquare move |
	"Try to push this pawn"
	destSquare _ square-8.
	(myPieces at: destSquare) = 0 ifFalse:[^self].
	(itsPieces at: destSquare) = 0 ifFalse:[^self].
	(move _ moveList at: (lastMoveIndex _ lastMoveIndex + 1))
		move: Pawn from: square to: destSquare.
	destSquare <= 8 "a promotion (can't be double-push so get out)"
		ifTrue:[^self promotePawn: move].

	"Try to double-push if possible"
	square > 48 ifFalse:[^self].
	destSquare _ square-16.
	(myPieces at: destSquare) = 0 ifFalse:[^self].
	(itsPieces at: destSquare) = 0 ifFalse:[^self].
	(moveList at: (lastMoveIndex _ lastMoveIndex + 1))
		doublePush: Pawn from: square to: destSquare.