postCopy
	whitePlayer == activePlayer ifTrue:[
		whitePlayer _ whitePlayer copy.
		blackPlayer _ blackPlayer copy.
		activePlayer _ whitePlayer.
	] ifFalse:[
		whitePlayer _ whitePlayer copy.
		blackPlayer _ blackPlayer copy.
		activePlayer _ blackPlayer.
	].
	whitePlayer opponent: blackPlayer.
	blackPlayer opponent: whitePlayer.
	whitePlayer board: self.
	blackPlayer board: self.
	self userAgent: nil.