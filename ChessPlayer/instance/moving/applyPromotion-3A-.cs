applyPromotion: move
	| piece |
	piece _ move promotion.
	piece = 0 ifFalse:[self replacePiece: move movingPiece with: piece at: move destinationSquare].