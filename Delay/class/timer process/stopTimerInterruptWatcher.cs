stopTimerInterruptWatcher
	"Reset the class variables that keep track of active Delays and re-start the timer interrupt watcher process. Any currently scheduled delays are forgotten."
	"Delay startTimerInterruptWatcher"
	self primSignal: nil atMilliseconds: 0.
	TimingSemaphore ifNotNil:[TimingSemaphore terminateProcess].