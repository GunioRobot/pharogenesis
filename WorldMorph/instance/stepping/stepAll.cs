stepAll
	self allExtantPlayers do:
		[:aPlayer |  aPlayer startRunning; step; stopRunning.
		aPlayer costume goHome]