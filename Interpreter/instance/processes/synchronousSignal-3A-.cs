synchronousSignal: aSemaphore 
	"Signal the given semaphore from within the interpreter."
	| excessSignals |
	self inline: false.
	(self isEmptyList: aSemaphore)
		ifTrue: ["no process is waiting on this semaphore"
			excessSignals _ self fetchInteger: ExcessSignalsIndex ofObject: aSemaphore.
			self storeInteger: ExcessSignalsIndex ofObject: aSemaphore withValue: excessSignals + 1]
		ifFalse: [self resume: (self removeFirstLinkOfList: aSemaphore)]