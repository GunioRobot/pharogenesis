findValidMovesAt: square
	"Find all the valid moves"
	| moveList |
	moveList _ (self findPossibleMovesAt: square) ifNil:[^nil].
	^moveList select:[:move| self isValidMove: move].