applyNormalMove: move
	| piece |
	(piece _ move capturedPiece) = EmptySquare 
		ifFalse:[opponent removePiece: piece at: move destinationSquare].
	^self movePiece: move movingPiece from: move sourceSquare to: move destinationSquare.