replacedPiece: oldPiece with: newPiece at: square white: isWhite
	self removedPiece: oldPiece at: square.
	self addedPiece: newPiece at: square white: isWhite