newPiece: piece white: isWhite
	| index selector m |
	index _ piece.
	isWhite ifFalse:[index _ index + 6].
	selector _ #(	
		whitePawnImage
		whiteKnightImage
		whiteBishopImage
		whiteRookImage
		whiteQueenImage
		whiteKingImage

		blackPawnImage
		blackKnightImage
		blackBishopImage
		blackRookImage
		blackQueenImage
		blackKingImage) at: index.
	m _ ChessPieceMorph new image: (self class perform: selector).
	m setProperty: #isWhite toValue: isWhite.
	m setProperty: #piece toValue: piece.
	^m