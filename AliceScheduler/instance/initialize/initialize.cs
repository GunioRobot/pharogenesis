initialize
	"Initialize the scheduler"

	"The scheduler starts at time 0"
	currentTime _ 0.
	elapsedTime _ 0.

	"The scheduler starts executing at 1:1 time"
	speed _ 1.

	"The scheduler starts running"
	isRunning _ true.

	"Determine the system time we're starting at"
	lastSystemTime _ Time millisecondClockValue / 1000.0.

	"Create the list of items to update"
	updateList _ OrderedCollection new.
