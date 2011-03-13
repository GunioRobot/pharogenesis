setDelay: milliseconds forSemaphore: aSemaphore
	"Private! Initialize this delay to signal the given semaphore after the given number of milliseconds."

	delayDuration := milliseconds asInteger.
	delayDuration < 0 ifTrue: [self error: 'delay times cannot be negative'].
	delaySemaphore := aSemaphore.
	beingWaitedOn := false.