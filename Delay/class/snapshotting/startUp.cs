startUp
	"Restart active delay, if any, when resuming a snapshot."

	self restoreResumptionTimes.
	ActiveDelay == nil ifFalse: [ActiveDelay activate].
	AccessProtect signal.
