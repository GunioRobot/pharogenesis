isValidMove: move
	"Is the given move actually valid for the receiver?
	If the receiver's king can't be taken after applying the move, it is."
	| copy |
	copy _ board copy.
	copy nextMove: move.
	^copy activePlayer findPossibleMoves notNil