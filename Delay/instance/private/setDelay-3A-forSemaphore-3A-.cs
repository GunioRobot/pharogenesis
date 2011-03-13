setDelay: milliseconds forSemaphore: aSemaphore
	"Private! Initialize this delay to signal the given semaphore after the given number of milliseconds."

	delayDuration _ milliseconds asInteger.
	delayDuration < 0 ifTrue: [self error: 'delay times cannot be negative'].
	delayDuration > (SmallInteger maxVal // 2)
		ifTrue: [self error: 'delay times can''t be longer than about six days (', (SmallInteger maxVal // 2) printString , 'ms)'].
	delaySemaphore _ aSemaphore.
	beingWaitedOn _ false.