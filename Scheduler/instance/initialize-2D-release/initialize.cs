initialize

	"Initializes the scheduler: sets Wonderland time to 0, creates empty lists for actions, alarms, and animations"

	currentTime _ 0.
	speed _ 1.
	isRunning _ true.
	alarmList _ OrderedCollection new.
	actionList _ OrderedCollection new.
	animationList _ OrderedCollection new.

	lastSystemTime _ Time millisecondClockValue / 1000.0.

	
