whitePawnCaptureAt: square direction: dir
	| destSquare move piece |
	destSquare _ square+8+dir.
	piece _ itsPieces at: destSquare.
	piece = 0 ifFalse:[
		(move _ moveList at: (lastMoveIndex _ lastMoveIndex + 1))
			move: Pawn from: square to: destSquare capture: piece.
		piece = King ifTrue:[kingAttack _ move].
		destSquare > 56 "a promotion"
			ifTrue:[self promotePawn: move].
	].
	"attempt an en-passant capture"
	enpassantSquare = destSquare ifTrue:[
		(moveList at: (lastMoveIndex _ lastMoveIndex + 1))
			captureEnPassant: Pawn from: square to: destSquare.
	].