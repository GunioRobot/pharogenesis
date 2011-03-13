spyEvery: millisecs on: aBlock
	"Create a spy and spy on the given block at the specified rate."
	"Spy only on the active process (in which aBlock is run)"

	| myDelay startTime time0 observedProcess |
	(aBlock isMemberOf: BlockClosure)
		ifFalse: [self error: 'spy needs a block here'].
	self class: aBlock receiver class method: aBlock method.
		"set up the probe"
	observedProcess := Processor activeProcess.
	myDelay := Delay forMilliseconds: millisecs.
	time0 := Time millisecondClockValue.
	gcStats := SmalltalkImage current getVMParameters.
	Timer ifNotNil: [ Timer terminate ].
	Timer := [
		[true] whileTrue: [
			startTime := Time millisecondClockValue.
			myDelay wait.
			self
				tally: Processor preemptedProcess suspendedContext
				in: (observedProcess == Processor preemptedProcess ifTrue: [observedProcess] ifFalse: [nil])
				"tally can be > 1 if ran a long primitive"
				by: (Time millisecondClockValue - startTime) // millisecs].
		nil] newProcess.
	Timer priority: Processor timingPriority-1.
		"activate the probe and evaluate the block"
	Timer resume.
	^ aBlock ensure: [
		"Collect gc statistics"
		SmalltalkImage current getVMParameters keysAndValuesDo: [ :idx :gcVal | 
			gcStats at: idx put: (gcVal - (gcStats at: idx))].
		"cancel the probe and return the value"
		Timer terminate.
		Timer := nil.
		time := Time millisecondClockValue - time0]