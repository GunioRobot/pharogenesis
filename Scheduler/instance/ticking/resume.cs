resume
	"If the scheduler was paused, resume it."

	isRunning ifFalse: 	[ isRunning _ true.
						  lastSystemTime _ (Time millisecondClockValue) / 1000.0.
						].

