validateGamePosition
	"This method does nothing but validating what you see (on screen) is what you get (from the board)."
	| square piece isWhite p |
	1 to: 64 do:[:idx|
		square _ self atSquare: idx.
		square hasSubmorphs 
			ifTrue:[piece _ square firstSubmorph valueOfProperty: #piece.
					isWhite _ square firstSubmorph valueOfProperty: #isWhite]
			ifFalse:[piece _ 0. isWhite _ nil].
		p _ board whitePlayer pieceAt: idx.
		idx = board whitePlayer castlingRookSquare ifTrue:[p _ ChessPlayer rook].
		isWhite == true ifTrue:[
			p = piece ifFalse:[self error:'White broken'].
		] ifFalse:[p = 0 ifFalse:[self error:'White broken']].
		p _ board blackPlayer pieceAt: idx.
		idx = board blackPlayer castlingRookSquare ifTrue:[p _ ChessPlayer rook].
		isWhite == false ifTrue:[
			p = piece ifFalse:[self error:'White broken'].
		] ifFalse:[p = 0 ifFalse:[self error:'White broken']].
	].