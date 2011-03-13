tick
	"Figure out how much time has elapsed since the last Scheduler tick and update all our actions, alarms, and animations"
	| deltaTime |
	isRunning ifTrue: [
		deltaTime _ (Time millisecondClockValue / 1000.0) - lastSystemTime.
		"See if the clock rolled over or the scheduler has been put to sleep for too long"
		(deltaTime < 0.0 or:[deltaTime > 2.0]) ifTrue:[
			"adjust for extra time"
			lastSystemTime _ (Time millisecondClockValue - 1) / 1000.0.
			deltaTime _ 1.0 / 1000.0].
		elapsedTime _ deltaTime * speed.
		currentTime _ currentTime + elapsedTime.
		lastSystemTime _ lastSystemTime + elapsedTime.
	
		self processAlarms.
		self processAnimations.
		self processActions.
	].
