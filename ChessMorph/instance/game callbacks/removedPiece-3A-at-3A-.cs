removedPiece: piece at: square
	animateMove ifFalse:[
		(self atSquare: square) removeAllMorphs.
	].