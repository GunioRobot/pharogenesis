promote: move to: promotion
	movingPiece _ move movingPiece.
	capturedPiece _ move capturedPiece.
	sourceSquare _ move sourceSquare.
	destinationSquare _ move destinationSquare. 
	type _ move moveType.
	type _ type bitOr: (promotion bitShift: PromotionShift).
