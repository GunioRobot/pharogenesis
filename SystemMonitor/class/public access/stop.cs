stop		"SystemMonitor stop"

	ActiveClock = nil
		ifFalse:
			[ActiveClock terminate.
			ActiveClock _ nil].
	ActiveMonitor = nil ifFalse: [ActiveMonitor _ nil].