undoDoublePushMove: move
	enpassantSquare _ 0.
	self movePiece: move movingPiece from: move destinationSquare to: move sourceSquare.