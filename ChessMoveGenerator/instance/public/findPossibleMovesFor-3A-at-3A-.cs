findPossibleMovesFor: player at: square
	"Find all possible moves at the given square. This method does not check if the move is legal, e.g., if the king of the player is under attack after the move. If the opponent is check mate (e.g., the king could be taken in the next move) the method returns nil. If the game is stale mate (e.g., the receiver has no move left) this method returns an empty array."
	| piece action |
	forceCaptures _ false.
	myPlayer _ player.
	myPieces _ player pieces.
	itsPieces _ player opponent pieces.
	castlingStatus _ player castlingStatus.
	enpassantSquare _ player opponent enpassantSquare.
	firstMoveIndex = lastMoveIndex ifFalse:[self error:'I am confused'].
	kingAttack _ nil.
	piece _ myPieces at: square.
	piece = 0 ifFalse:[
		action _ #(movePawnAt:
					moveKnightAt:
					moveBishopAt:
					moveRookAt:
					moveQueenAt:
					moveKingAt:) at: piece.
		self perform: action with: square.
	].
	^self moveList