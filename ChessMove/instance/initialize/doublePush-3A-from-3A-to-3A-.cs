doublePush: aPiece from: startSquare to: endSquare
	movingPiece _ aPiece.
	sourceSquare _ startSquare.
	destinationSquare _ endSquare.
	type _ MoveDoublePush.
	capturedPiece _ 0.