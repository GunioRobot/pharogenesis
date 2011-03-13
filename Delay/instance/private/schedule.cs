schedule
	"Schedule this delay"
	beingWaitedOn ifTrue: [^self error: 'This Delay has already been scheduled.'].
	resumptionTime := Time millisecondClockValue + delayDuration.
	AccessProtect critical:[
		ScheduledDelay := self.
		TimingSemaphore signal.
	].