checkForInterrupts
	"Check for possible interrupts and handle one if necessary."
	| sema now |
	self inline: false.

	"Mask so same wrapping as primitiveMillisecondClock"
	now _ self ioMSecs bitAnd: MillisecondClockMask.

	self interruptCheckForced ifFalse: [
		"don't play with the feedback if we forced a check. It only makes life difficult"
		now - lastTick < interruptChecksEveryNms
			ifTrue: ["wrapping is not a concern, it'll get caught quickly  
				enough. This clause is trying to keep a reasonable  
				guess of how many times per 	interruptChecksEveryNms we are calling  
				quickCheckForInterrupts. Not sure how effective it really is."
				interruptCheckCounterFeedBackReset _ interruptCheckCounterFeedBackReset + 10]
			ifFalse: [interruptCheckCounterFeedBackReset <= 1000
					ifTrue: [interruptCheckCounterFeedBackReset _ 1000]
					ifFalse: [interruptCheckCounterFeedBackReset _ interruptCheckCounterFeedBackReset - 12]]].

	"reset the interrupt check counter"
	interruptCheckCounter _ interruptCheckCounterFeedBackReset.

	signalLowSpace
		ifTrue: [signalLowSpace _ false. "reset flag"
			sema _ self splObj: TheLowSpaceSemaphore.
			sema = nilObj ifFalse: [self synchronousSignal: sema]].

	now < lastTick
		ifTrue: ["millisecond clock wrapped so correct the nextPollTick"
			nextPollTick _ nextPollTick - MillisecondClockMask - 1].
	now >= nextPollTick
		ifTrue: [self ioProcessEvents.
			"sets interruptPending if interrupt key pressed"
			nextPollTick _ now + 200
			"msecs to wait before next call to ioProcessEvents.  
			Note that strictly speaking we might need to update  
			'now' at this point since ioProcessEvents could take a  
			very long time on some platforms"].
	interruptPending
		ifTrue: [interruptPending _ false.
			"reset interrupt flag"
			sema _ self splObj: TheInterruptSemaphore.
			sema = nilObj
				ifFalse: [self synchronousSignal: sema]].

	nextWakeupTick ~= 0
		ifTrue: [now < lastTick
				ifTrue: ["the clock has wrapped. Subtract the wrap  
					interval from nextWakeupTick - this might just  
					possibly result in 0. Since this is used as a flag  
					value for 'no timer' we do the 0 check above"
					nextWakeupTick _ nextWakeupTick - MillisecondClockMask - 1].
			now >= nextWakeupTick
				ifTrue: [nextWakeupTick _ 0.
					"set timer interrupt to 0 for 'no timer'"
					sema _ self splObj: TheTimerSemaphore.
					sema = nilObj ifFalse: [self synchronousSignal: sema]]].

	"signal any pending finalizations"
	pendingFinalizationSignals > 0
		ifTrue: [sema _ self splObj: TheFinalizationSemaphore.
			(self fetchClassOf: sema) = (self splObj: ClassSemaphore)
				ifTrue: [self synchronousSignal: sema].
			pendingFinalizationSignals _ 0].

	"signal all semaphores in semaphoresToSignal"
	(semaphoresToSignalCountA > 0 or: [semaphoresToSignalCountB > 0])
		ifTrue: [self signalExternalSemaphores].

	"update the tracking value"
	lastTick _ now