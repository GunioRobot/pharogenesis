findAllPossibleMovesFor: player 
	"Find all possible moves. This method does not check if the move is legal, e.g., if the king of the player is under attack after the move. If the opponent is check mate (e.g., the king could be taken in the next move) the method returns nil. If the game is stale mate (e.g., the receiver has no move left) this method returns an empty array."

	| piece actions square |
	myPlayer := player.
	myPieces := player pieces.
	itsPieces := player opponent pieces.
	castlingStatus := player castlingStatus.
	enpassantSquare := player opponent enpassantSquare.
	firstMoveIndex = lastMoveIndex ifFalse: [self error: 'I am confused'].
	kingAttack := nil.
	actions := myPlayer isWhitePlayer 
		ifTrue: 
			[#(#moveWhitePawnAt: #moveKnightAt: #moveBishopAt: #moveRookAt: #moveQueenAt: #moveWhiteKingAt:)]
		ifFalse: 
			[#(#moveBlackPawnAt: #moveKnightAt: #moveBishopAt: #moveRookAt: #moveQueenAt: #moveBlackKingAt:)].
	square := 0.
	[square < 64] whileTrue: 
			["Note: The following is only to skip empty fields efficiently.
		It could well be replaced by going through each field and test it
		for zero but this is *much* faster."

			square := String 
						findFirstInString: myPieces
						inSet: EmptyPieceMap
						startingAt: square + 1.
			square = 0 ifTrue: [^self moveList].
			piece := myPieces at: square.
			self perform: (actions at: piece) with: square.
			kingAttack ifNotNil: [^self moveList]].
	^self moveList