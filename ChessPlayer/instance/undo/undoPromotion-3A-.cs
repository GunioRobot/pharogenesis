undoPromotion: move
	| piece |
	piece _ move promotion.
	piece = 0 ifFalse:[self replacePiece: piece with: move movingPiece at: move destinationSquare].