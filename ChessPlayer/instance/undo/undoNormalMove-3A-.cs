undoNormalMove: move
	| piece |
	self movePiece: move movingPiece from: move destinationSquare to: move sourceSquare.
	(piece _ move capturedPiece) = EmptySquare 
		ifFalse:[opponent addPiece: piece at: move destinationSquare].
