wait
	"Suspend the process of the caller for the amount of time specified
	 when the receiver was created."

	beingWaitedOn ifTrue: [ self error: 'A process is already waiting on this Delay' ].
	AccessProtect critical: [
		beingWaitedOn _ true.
		resumptionTime _ Time millisecondClockValue + delayDuration.
		ActiveDelay == nil
			ifTrue: [ self activate ]
			ifFalse: [
				resumptionTime < ActiveDelay resumptionTime
					ifTrue: [
						SuspendedDelays add: ActiveDelay.
						self activate ]
					ifFalse: [ SuspendedDelays add: self ].
			].
	].
	delaySemaphore wait.