tick

	"Figure out how much time has elapsed since the last Scheduler tick and update all our actions, alarms, and animations"

	isRunning ifTrue: [
			elapsedTime _ ((Time millisecondClockValue / 1000.0) - lastSystemTime) * speed.

			"if elapsedTime is negative the clock rolled over; deal with it"
			(elapsedTime < 0) ifTrue: [lastSystemTime _ 0. elapsedTime _
										(Time millisecondClockValue) / 1000.0].

			currentTime _ currentTime + elapsedTime.
			lastSystemTime _ lastSystemTime + elapsedTime.
	
			self processAlarms.
			self processAnimations.
			self processActions.
						].
