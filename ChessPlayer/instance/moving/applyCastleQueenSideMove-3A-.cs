applyCastleQueenSideMove: move
	self movePiece: move movingPiece from: move sourceSquare to: move destinationSquare.
	self movePiece: Rook from: move sourceSquare-4 to: (castlingRookSquare _ move sourceSquare-1).
	pieces at: castlingRookSquare put: King.
	castlingStatus _ castlingStatus bitOr: CastlingDone.