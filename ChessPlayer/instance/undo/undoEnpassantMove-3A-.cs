undoEnpassantMove: move
	self movePiece: move movingPiece from: move destinationSquare to: move sourceSquare.
	opponent addPiece: move capturedPiece at: move destinationSquare - 
		(self isWhitePlayer ifTrue:[8] ifFalse:[-8]).
