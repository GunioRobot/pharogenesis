addWhitePieces
	self addPiece: Rook at: 1.
	self addPiece: Knight at: 2.
	self addPiece: Bishop at: 3.
	self addPiece: Queen at: 4.
	self addPiece: King at: 5.
	self addPiece: Bishop at: 6.
	self addPiece: Knight at: 7.
	self addPiece: Rook at: 8.
	9 to: 16 do:[:i| self addPiece: Pawn at: i].
