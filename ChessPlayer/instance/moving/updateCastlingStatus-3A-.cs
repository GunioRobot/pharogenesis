updateCastlingStatus: move

	"Cannot castle when king has moved"
	(move movingPiece = King) 
		ifTrue:[^castlingStatus _ castlingStatus bitOr: CastlingDisableAll].

	"See if a rook has moved"
	(move movingPiece = Rook) ifFalse:[^self].

	self isWhitePlayer ifTrue:[
		(move sourceSquare = 1) 
			ifTrue:[^castlingStatus _ castlingStatus bitOr: CastlingDisableQueenSide].
		(move sourceSquare = 8) 
			ifTrue:[^castlingStatus _ castlingStatus bitOr: CastlingDisableKingSide].
	] ifFalse:[
		(move sourceSquare = 57) 
			ifTrue:[^castlingStatus _ castlingStatus bitOr: CastlingDisableQueenSide].
		(move sourceSquare = 64) 
			ifTrue:[^castlingStatus _ castlingStatus bitOr: CastlingDisableKingSide].
	].