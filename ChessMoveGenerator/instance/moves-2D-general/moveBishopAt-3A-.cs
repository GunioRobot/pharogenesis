moveBishopAt: square
	| moves |
	moves _ BishopMoves at: square.
	1 to: moves size do:[:i|
		self movePiece: Bishop along: (moves at: i) at: square.
	].
