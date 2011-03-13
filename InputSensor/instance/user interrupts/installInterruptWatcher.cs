installInterruptWatcher
	"Initialize the interrupt watcher process. Terminate the old process if any."
	"Sensor installInterruptWatcher"

	InterruptWatcherProcess == nil ifFalse: [InterruptWatcherProcess terminate].
	InterruptSemaphore _ Semaphore new.
	InterruptWatcherProcess _ [self userInterruptWatcher] newProcess.
	InterruptWatcherProcess priority: Processor lowIOPriority.
	InterruptWatcherProcess resume.
	self primInterruptSemaphore: InterruptSemaphore.