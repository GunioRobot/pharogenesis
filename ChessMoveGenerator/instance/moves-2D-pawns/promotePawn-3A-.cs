promotePawn: move
	"Duplicate the given move and embed all promotion types"
	(moveList at: (lastMoveIndex _ lastMoveIndex + 1)) promote: move to: Knight.
	(moveList at: (lastMoveIndex _ lastMoveIndex + 1)) promote: move to: Bishop.
	(moveList at: (lastMoveIndex _ lastMoveIndex + 1)) promote: move to: Rook.
	move promote: move to: Queen.