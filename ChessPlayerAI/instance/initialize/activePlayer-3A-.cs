activePlayer: aPlayer
	player _ aPlayer.
	board _ player board.
	generator _ board generator.
	self reset.