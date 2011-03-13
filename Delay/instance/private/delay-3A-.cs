delay: millisecondCount
	"Initialize this delay for the given number of milliseconds."

	delayDuration _ millisecondCount.
	delaySemaphore _ Semaphore new.
	beingWaitedOn _ false.