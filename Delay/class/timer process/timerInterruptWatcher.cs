timerInterruptWatcher
	"This loop runs in its own process. It waits for a timer interrupt and wakes up the active delay. Note that timer interrupts are only enabled when there are active delays."

	[true] whileTrue: [
		TimingSemaphore wait.
		AccessProtect critical: [
			ActiveDelay == nil ifFalse: [
				ActiveDelay signalWaitingProcess.
				Time millisecondClockValue < ActiveDelayStartTime
					ifTrue: [  "clock wrapped"
						self saveResumptionTimes.
						self restoreResumptionTimes]].
			SuspendedDelays isEmpty
				ifTrue: [
					ActiveDelay _ nil.
					ActiveDelayStartTime _ nil]
				ifFalse: [
					SuspendedDelays removeFirst activate]]].
