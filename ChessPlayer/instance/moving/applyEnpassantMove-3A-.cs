applyEnpassantMove: move
	opponent removePiece: move capturedPiece at: move destinationSquare - 
		(self isWhitePlayer ifTrue:[8] ifFalse:[-8]).
	^self movePiece: move movingPiece from: move sourceSquare to: move destinationSquare