gameLost

	state _ #lost.
	elapsedTimeDisplay stop.
	cardsRemainingDisplay highlighted: true; flash: true.
	Statistics gameLost: self currentGame