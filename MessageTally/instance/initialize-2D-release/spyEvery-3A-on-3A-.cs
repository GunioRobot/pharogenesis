spyEvery: millisecs on: aBlock 
	"Create a spy and spy on the given block at the specified rate."

	| myDelay value startTime time0 |
	(aBlock isMemberOf: BlockContext)
		ifFalse: [self error: 'spy needs a block here'].
	self class: aBlock receiver class method: aBlock method.
		"set up the probe"
	ObservedProcess _ Processor activeProcess.
	myDelay := Delay forMilliseconds: millisecs.
	time0 := Time millisecondClockValue.
	Timer :=
		[[true] whileTrue: 
			[startTime := Time millisecondClockValue.
			myDelay wait.
			self tally: ObservedProcess suspendedContext
				"tally can be > 1 if ran a long primitive"
				by: (Time millisecondClockValue - startTime) // millisecs].
		nil] newProcess.
	Timer priority: Processor userInterruptPriority.
		"activate the probe and evaluate the block"
	Timer resume.
	value := aBlock value.
		"cancel the probe and return the value"
	Timer terminate.
	time := Time millisecondClockValue - time0.
	^value