schedule
	"Private! Schedule this Delay, but return immediately rather than waiting. The receiver's semaphore will be signalled when its delay duration has elapsed."

	beingWaitedOn ifTrue: [self error: 'This Delay has already been scheduled.'].

	TimerEventLoop ifNotNil:[^self scheduleEvent].
	AccessProtect critical: [
		beingWaitedOn := true.
		resumptionTime := Time millisecondClockValue + delayDuration.
		ActiveDelay == nil
			ifTrue: [self activate]
			ifFalse: [
				resumptionTime < ActiveDelay resumptionTime
					ifTrue: [
						SuspendedDelays add: ActiveDelay.
						self activate]
					ifFalse: [SuspendedDelays add: self]]].
