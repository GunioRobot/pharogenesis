initialize
	"Initialize the class variables that keep track of active Delays."
	"Delay initialize"

	TimingSemaphore == nil ifFalse: [ TimingSemaphore terminateProcess ].
	TimingSemaphore _ Semaphore new.
	AccessProtect _ Semaphore forMutualExclusion.
	SuspendedDelays _ 
		SortedCollection sortBlock: 
			[ :d1 :d2 | d1 resumptionTime <= d2 resumptionTime].
	ActiveDelay _ nil.
	[self timerInterruptWatcher] forkAt: Processor timingPriority.