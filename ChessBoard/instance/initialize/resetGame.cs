resetGame
	hashKey _ hashLock _ 0.
	whitePlayer _ ChessPlayer new initialize.
	blackPlayer _ ChessPlayer new initialize.
	whitePlayer opponent: blackPlayer.
	whitePlayer board: self.
	blackPlayer opponent: whitePlayer.
	blackPlayer board: self.
	activePlayer _ whitePlayer.
	searchAgent reset: self.
	userAgent ifNotNil:[userAgent gameReset].