spyEvery: millisecs onProcess: aProcess forMilliseconds: msecDuration 
	"Create a spy and spy on the given process at the specified rate."
	| myDelay time0 endTime sem |
	(aProcess isKindOf: Process)
		ifFalse: [self error: 'spy needs a Process here'].
	self class: aProcess suspendedContext receiver class method: aProcess suspendedContext method.
	"set up the probe"
	ObservedProcess _ aProcess.
	myDelay _ Delay forMilliseconds: millisecs.
	time0 _ Time millisecondClockValue.
	endTime _ time0 + msecDuration.
	sem _ Semaphore new.
	gcStats _ SmalltalkImage current  getVMParameters.
	Timer _ [[| startTime | 
			startTime _ Time millisecondClockValue.
			myDelay wait.
			self tally: ObservedProcess suspendedContext by: Time millisecondClockValue - startTime // millisecs.
			startTime < endTime] whileTrue.
			sem signal]
				forkAt: (ObservedProcess priority + 1 min: Processor highestPriority).
	"activate the probe and wait for it to finish"
	sem wait.
	"Collect gc statistics"
	SmalltalkImage current  getVMParameters keysAndValuesDo:
		[:idx :gcVal| gcStats at: idx put: (gcVal - gcStats at: idx)].
	time _ Time millisecondClockValue - time0