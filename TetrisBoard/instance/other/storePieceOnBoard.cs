storePieceOnBoard

	currentBlock submorphs do: [ :each |
		self addMorph: each.
		((each top - self top) // self cellSize y) < 3 ifTrue: [
			paused _ gameOver _ true.
		].
	].
	currentBlock delete.
	currentBlock _ nil.
	self checkForFullRows.
	self score: score + 10.
	delay _ delay - 2 max: 80.

