move: aPiece from: startSquare to: endSquare capture: capture
	movingPiece _ aPiece.
	sourceSquare _ startSquare.
	destinationSquare _ endSquare.
	capturedPiece _ capture.
	type _ MoveNormal.
