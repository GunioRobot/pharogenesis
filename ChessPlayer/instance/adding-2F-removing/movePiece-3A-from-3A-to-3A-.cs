movePiece: piece from: sourceSquare to: destSquare
	| score |
	score _ PieceCenterScores at: piece.
	positionalValue _ positionalValue - (score at: sourceSquare).
	positionalValue _ positionalValue + (score at: destSquare).
	pieces at: sourceSquare put: 0.
	pieces at: destSquare put: piece.
	board updateHash: piece at: sourceSquare from: self.
	board updateHash: piece at: destSquare from: self.
	self userAgent ifNotNil:[self userAgent movedPiece: piece from: sourceSquare to: destSquare].