activate
	"Private! Make the receiver the Delay to be awoken when the next timer interrupt occurs. This method should only be called from a block protected by the AccessProtect semaphore."

	ActiveDelay _ self.
	ActiveDelayStartTime _ Time millisecondClockValue.
	ActiveDelayStartTime >= resumptionTime ifTrue:[
		"if my time is now or in the past, trigger me and get the next in line activated"
		ActiveDelay signalWaitingProcess.
		SuspendedDelays isEmpty ifTrue:[
			ActiveDelay _ nil.
			ActiveDelayStartTime _ nil.
		] ifFalse:[SuspendedDelays removeFirst activate].
	] ifFalse:[
		TimingSemaphore initSignals.
		Delay primSignal: TimingSemaphore atMilliseconds: resumptionTime.
	].