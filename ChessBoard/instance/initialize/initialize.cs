initialize
	generator ifNil:[generator _ ChessMoveGenerator new initialize].
	searchAgent ifNil:[searchAgent _ ChessPlayerAI new initialize].
	self resetGame.
