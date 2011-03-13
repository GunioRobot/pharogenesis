activate
	"Make the receiver the Delay to be signalled when the next timer
	interrupt occurs. This method should only be called from a block
	protected by the AccessProtect semaphore."

	ActiveDelay _ self.
	ActiveDelayStartTime _ Time millisecondClockValue.
	TimingSemaphore initSignals.
	Processor signal: TimingSemaphore atTime: resumptionTime.