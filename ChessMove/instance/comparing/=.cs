= aMove
	movingPiece = aMove movingPiece ifFalse:[^false].
	capturedPiece = aMove capturedPiece ifFalse:[^false].
	type = aMove type ifFalse:[^false].
	sourceSquare = aMove sourceSquare ifFalse:[^false].
	destinationSquare = aMove destinationSquare ifFalse:[^false].
	^true