moveRookAt: square
	| moves |
	moves _ RookMoves at: square.
	1 to: moves size do:[:i|
		self movePiece: Rook along: (moves at: i) at: square.
	].
