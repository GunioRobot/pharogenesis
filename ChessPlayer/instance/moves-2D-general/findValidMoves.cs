findValidMoves
	"Find all the valid moves"
	| moveList |
	moveList _ self findPossibleMoves ifNil:[^nil].
	^moveList select:[:move| self isValidMove: move].