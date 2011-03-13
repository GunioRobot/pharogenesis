recordTimeRemaining
	"Record (in resumptionTime) the amount of time remaining for the active
	delay (the receiver) just before a snapshot. The delay will be resumed
	when the snapshot resumes."

	| timeSoFar |
	timeSoFar _ Time millisecondClockValue - ActiveDelayStartTime.
	resumptionTime _ delayDuration - timeSoFar.
