captureEnPassant: aPiece from: startSquare to: endSquare
	movingPiece _ capturedPiece _ aPiece.
	sourceSquare _ startSquare.
	destinationSquare _ endSquare.
	type _ MoveCaptureEnPassant.