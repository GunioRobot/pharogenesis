replacePiece: oldPiece with: newPiece at: square
	pieces at: square put: newPiece.
	materialValue _ materialValue - (PieceValues at: oldPiece) + (PieceValues at: newPiece).
	positionalValue _ positionalValue - ((PieceCenterScores at: oldPiece) at: square).
	positionalValue _ positionalValue + ((PieceCenterScores at: newPiece) at: square).

	oldPiece = Pawn ifTrue:[numPawns _ numPawns - 1].
	newPiece = Pawn ifTrue:[numPawns _ numPawns + 1].
	board updateHash: oldPiece at: square from: self.
	board updateHash: newPiece at: square from: self.
	self userAgent ifNotNil:[self userAgent replacedPiece: oldPiece with: newPiece at: square white: self isWhitePlayer].