timerInterruptWatcher
	"This loop runs in its own process. It waits for a timer interrupt and
	wakes up the active delay. Note that timer interrupts are only enabled
	when there are active delays."
	| nowTime |
	[true]
		whileTrue: [TimingSemaphore wait.
			AccessProtect
				critical: [ActiveDelay == nil
						ifFalse: [ActiveDelay signalWaitingProcess.
							(nowTime := Time millisecondClockValue) < ActiveDelayStartTime
								ifTrue: ["clock wrapped so adjust the resumption
									times of all the suspended delays. No
									point adjusting the active delay since
									we've just triggered it"
									SuspendedDelays
										do: [:d | d adjustResumptionTimeOldBase: ActiveDelayStartTime newBase: nowTime]]].
					SuspendedDelays isEmpty
						ifTrue: [ActiveDelay := nil.
							ActiveDelayStartTime := nil]
						ifFalse: [SuspendedDelays removeFirst activate]]]