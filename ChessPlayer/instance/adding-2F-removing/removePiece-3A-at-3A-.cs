removePiece: piece at: square
	pieces at: square put: 0.
	materialValue _ materialValue - (PieceValues at: piece).
	positionalValue _ positionalValue - ((PieceCenterScores at: piece) at: square).
	piece = Pawn ifTrue:[numPawns _ numPawns - 1].
	board updateHash: piece at: square from: self.
	self userAgent ifNotNil:[self userAgent removedPiece: piece at: square].