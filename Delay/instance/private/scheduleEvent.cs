scheduleEvent
	"Schedule this delay"
	resumptionTime := Time millisecondClockValue + delayDuration.
	AccessProtect critical:[
		ScheduledDelay := self.
		TimingSemaphore signal.
	].