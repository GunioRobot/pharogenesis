move: aPiece from: startSquare to: endSquare
	movingPiece _ aPiece.
	sourceSquare _ startSquare.
	destinationSquare _ endSquare.
	type _ MoveNormal.
	capturedPiece _ 0.