moveCastlingQueenSide: aPiece from: startSquare to: endSquare
	movingPiece _ aPiece.
	sourceSquare _ startSquare.
	destinationSquare _ endSquare.
	type _ MoveCastlingQueenSide.
	capturedPiece _ 0.