continueAfterSnapshot
	"Continue the active delay after resuming a snapshot."
	"Note: During a snapshot, the resumptionTime variable is used to record
	the time remaining on the active duration."

	resumptionTime _ Time millisecondClockValue + resumptionTime.
	ActiveDelayStartTime _ Time millisecondClockValue.
	TimingSemaphore initSignals.
	Processor signal: TimingSemaphore atTime: resumptionTime.