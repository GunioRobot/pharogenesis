undoCastleKingSideMove: move
	self prepareNextMove. "in other words, remove extra kings"
	self movePiece: move movingPiece from: move destinationSquare to: move sourceSquare.
	self movePiece: Rook from: move sourceSquare+1 to: move sourceSquare+3.