startThinking
	self isThinking ifTrue:[^self].
	self activePlayer: board activePlayer.
	self thinkStep.