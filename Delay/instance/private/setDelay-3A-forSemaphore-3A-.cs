setDelay: millisecondCount forSemaphore: aSemaphore
	"Private! Initialize this delay to signal the given semaphore after the given number of milliseconds."

	delayDuration _ millisecondCount.
	delaySemaphore _ aSemaphore.
	beingWaitedOn _ false.
