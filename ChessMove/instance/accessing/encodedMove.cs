encodedMove
	"Return an integer encoding enough of a move for printing"
	^destinationSquare + 
		(sourceSquare bitShift: 8) +
		(movingPiece bitShift: 16) +
		(capturedPiece bitShift: 24)