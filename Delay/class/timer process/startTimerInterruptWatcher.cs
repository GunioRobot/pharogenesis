startTimerInterruptWatcher
	"Reset the class variables that keep track of active Delays and re-start the timer interrupt watcher process. Any currently scheduled delays are forgotten."
	"Delay startTimerInterruptWatcher"

	| p |
	self primSignal: nil atMilliseconds: 0.
	TimingSemaphore == nil
		ifFalse: [TimingSemaphore terminateProcess].
	TimingSemaphore _ Semaphore new.
	AccessProtect _ Semaphore forMutualExclusion.
	SuspendedDelays _ 
		SortedCollection sortBlock: 
			[:d1 :d2 | d1 resumptionTime <= d2 resumptionTime].
	ActiveDelay _ nil.
	p _ [self timerInterruptWatcher] newProcess.
	p priority: Processor timingPriority.
	p resume.
