newGame
	board ifNil:[board _ ChessBoard new].
	board initialize.
	board userAgent: self.
	board initializeNewBoard.
	history _ OrderedCollection new.
	redoList _ OrderedCollection new.
