hash
	^((movingPiece hash bitXor: capturedPiece hash) bitXor:
		(sourceSquare hash bitXor: destinationSquare hash)) bitXor: type hash