shutDown
	InterruptWatcherProcess ifNotNil: [
		InterruptWatcherProcess terminate.
		InterruptWatcherProcess _ nil ].