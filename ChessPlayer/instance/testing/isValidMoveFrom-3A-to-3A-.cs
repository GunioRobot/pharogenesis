isValidMoveFrom: sourceSquare to: destSquare
	| move |
	move _ (self findValidMovesAt: sourceSquare)
			detect:[:any| any destinationSquare = destSquare] ifNone:[nil].
	^move notNil