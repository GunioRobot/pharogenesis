moveBlackKingAt: square
	| capture |
	(KingMoves at: square) do:[:destSquare|
		(myPieces at: destSquare) = 0 ifTrue:[
			capture _ itsPieces at: destSquare.
			(forceCaptures and:[capture = 0]) ifFalse:[
				(moveList at: (lastMoveIndex _ lastMoveIndex + 1))
					move: King from: square to: destSquare capture: capture.
				capture = King ifTrue:[kingAttack _ moveList at: lastMoveIndex].
			].
		].
	].
	forceCaptures ifTrue:[^self].
	"now consider castling"
	self canCastleBlackKingSide ifTrue:[
		(moveList at: (lastMoveIndex _ lastMoveIndex + 1))
			moveCastlingKingSide: King from: square to: square+2.
	].
	self canCastleBlackQueenSide ifTrue:[
		(moveList at: (lastMoveIndex _ lastMoveIndex + 1))
			moveCastlingQueenSide: King from: square to: square-2.
	].