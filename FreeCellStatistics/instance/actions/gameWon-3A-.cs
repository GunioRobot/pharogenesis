gameWon: gameNumber
	sessionWins _ sessionWins + 1.
	totalWins _ totalWins + 1.
	gameNumber = lastGameWon ifFalse:
		[gameNumber = lastGameLost ifTrue:
			["Finally won a game by replaying"
			lossesWithReplay _ lossesWithReplay - 1].
		winsWithReplay _ winsWithReplay + 1].
	lastGameWon _ gameNumber.
	currentType = #wins
		ifTrue: [currentCount _ currentCount + 1]
		ifFalse: [currentCount _ 1.
				currentType _ #wins].
	self updateStreak.
	self changed