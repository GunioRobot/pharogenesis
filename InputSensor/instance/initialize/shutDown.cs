shutDown
	InterruptWatcherProcess == nil ifFalse: [
		InterruptWatcherProcess terminate.
		InterruptWatcherProcess terminate].