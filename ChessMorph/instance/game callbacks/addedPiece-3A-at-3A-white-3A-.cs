addedPiece: piece at: square white: isWhite
	| m |
	m _ self newPiece: piece white: isWhite.
	m on: #mouseDown send: #dragPiece:from: to: self.
	m setProperty: #chessBoard toValue: self.
	(self atSquare: square) removeAllMorphs; addMorphCentered: m.