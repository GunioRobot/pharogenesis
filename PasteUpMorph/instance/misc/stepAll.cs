stepAll
	self presenter allExtantPlayers do:
		[:aPlayer | 
			aPlayer startRunning; step; stopRunning]