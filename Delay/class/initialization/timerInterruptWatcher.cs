timerInterruptWatcher
	"This loop runs in its own process. It waits for a timer interrupt and
	wakes up the active delay. Note that timer interrupts are only scheduled
	when there are active delays."

	[true] whileTrue: [
		TimingSemaphore wait.
		AccessProtect critical: [
			ActiveDelay signalWaitingProcess.
			SuspendedDelays isEmpty
				ifTrue: [
					ActiveDelay _ nil.
					ActiveDelayStartTime _ nil.
				] ifFalse: [ SuspendedDelays removeFirst activate ].
		].
	].
