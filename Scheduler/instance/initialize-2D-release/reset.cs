reset
	"Clears the animation, action, and alarm lists and resets the Wonderland time to 0"

	currentTime _ 0.
	speed _ 1.
	isRunning _ true.
	lastSystemTime _ (Time millisecondClockValue) / 1000.0.

	alarmList _ OrderedCollection new.
	actionList _ OrderedCollection new.
	animationList _ OrderedCollection new.