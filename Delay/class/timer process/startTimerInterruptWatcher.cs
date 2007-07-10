startTimerInterruptWatcher
	"Reset the class variables that keep track of active Delays and re-start the timer interrupt watcher process. Any currently scheduled delays are forgotten."
	"Delay startTimerInterruptWatcher"
	| p |
	self stopTimerEventLoop.
	self stopTimerInterruptWatcher.
	TimingSemaphore := Semaphore new.
	AccessProtect := Semaphore forMutualExclusion.
	SuspendedDelays := 
		SortedCollection sortBlock: 
			[:d1 :d2 | d1 resumptionTime <= d2 resumptionTime].
	ActiveDelay := nil.
	p := [self timerInterruptWatcher] newProcess.
	p priority: Processor timingPriority.
	p resume.
