gameLost: gameNumber

	"Don't count multiple losses of the same game"
	gameNumber = lastGameLost ifTrue: [^ self].
	lastGameLost _ gameNumber.

	sessionLosses _ sessionLosses + 1.
	totalLosses _ totalLosses + 1.
	lossesWithReplay _ lossesWithReplay + 1.
	currentType = #losses
		ifTrue: [currentCount _ currentCount + 1]
		ifFalse: 
			[currentCount _ 1.
			currentType _ #losses].
	self updateStreak.
	self changed