addBlackPieces
	self initialize.
	49 to: 56 do:[:i| self addPiece: Pawn at: i].
	self addPiece: Rook at: 57.
	self addPiece: Knight at: 58.
	self addPiece: Bishop at: 59.
	self addPiece: Queen at: 60.
	self addPiece: King at: 61.
	self addPiece: Bishop at: 62.
	self addPiece: Knight at: 63.
	self addPiece: Rook at: 64.
