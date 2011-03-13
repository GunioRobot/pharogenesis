spyEvery: millisecs on: aBlock 
	"Create a spy and spy on the given block at the specified rate."

	| myDelay value |
	(aBlock isMemberOf: BlockContext)
		ifFalse: [self error: 'spy needs a block here'].
	self class: aBlock receiver class method: aBlock method.
		"set up the probe"
	ObservedProcess _ Processor activeProcess.
	myDelay _ Delay forMilliseconds: millisecs.
	Timer _
		[[true] whileTrue: 
			[myDelay wait.
			self tally: ObservedProcess suspendedContext].
		nil] newProcess.
	Timer priority: Processor userInterruptPriority.
		"activate the probe and evaluate the block"
	Timer resume.
	value _ aBlock value.
		"cancel the probe and return the value"
	Timer terminate.
	^value