moveQueenAt: square
	| moves |
	moves _ RookMoves at: square.
	1 to: moves size do:[:i|
		self movePiece: Queen along: (moves at: i) at: square.
	].
	moves _ BishopMoves at: square.
	1 to: moves size do:[:i|
		self movePiece: Queen along: (moves at: i) at: square.
	].