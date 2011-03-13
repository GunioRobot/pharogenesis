buildProvider: p
	self beNotInteractiveDuring: [
		p registeredServices do: [:each | self addService: each provider: p class].
		p replayPreferences]
	