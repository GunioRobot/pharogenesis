moveEncoded: encodedMove
	destinationSquare _ encodedMove bitAnd: 255.
	sourceSquare _ (encodedMove bitShift: -8) bitAnd: 255.
	movingPiece _ (encodedMove bitShift: -16) bitAnd: 255.
	capturedPiece _ (encodedMove bitShift: -24) bitAnd: 255.
	type _ MoveNormal.
