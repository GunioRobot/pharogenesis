incrementBy: amount
	"This method allows animations to be stepped through; the user pauses the Scheduler and then repeatedly issues incrementBy messages with the desired increment"

	currentTime _ currentTime + amount.
	lastSystemTime _ lastSystemTime + amount.
	
	self processActions.
	self processAlarms.
	self processAnimations.