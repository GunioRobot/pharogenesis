findPossibleMovesFor: player
	"Find all possible moves. This method does not check if the move is legal, e.g., if the king of the player is under attack after the move. If the opponent is check mate (e.g., the king could be taken in the next move) the method returns nil. If the game is stale mate (e.g., the receiver has no move left) this method returns an empty array."
	forceCaptures _ false.
	^self findAllPossibleMovesFor: player.