positionInScore: pos

	self isPlaying ifTrue: [^ self "ignore rude intrusion"].
	ticksSinceStart _ pos * durationInTicks.
	done _ false.

