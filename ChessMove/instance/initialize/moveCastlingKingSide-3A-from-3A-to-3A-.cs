moveCastlingKingSide: aPiece from: startSquare to: endSquare
	movingPiece _ aPiece.
	sourceSquare _ startSquare.
	destinationSquare _ endSquare.
	type _ MoveCastlingKingSide.
	capturedPiece _ 0.