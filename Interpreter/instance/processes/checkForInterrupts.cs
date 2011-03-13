checkForInterrupts
	"Check for possible interrupts and handle one if necessary."

	| sema now |
	self inline: false.

	"Mask so same wrap as primitiveMillisecondClock"
	now _ self ioMSecs bitAnd: MillisecondClockMask. 

	now < lastTick ifTrue: [
		"millisecond clock wrapped"
		nextPollTick _ now + (nextPollTick - lastTick).
		nextWakeupTick ~= 0
			ifTrue: [nextWakeupTick _ now + (nextWakeupTick - lastTick)]].

	(now - lastTick) < interruptChecksEveryNms ifTrue: "wrapping is not a concern"
	    [interruptCheckCounterFeedBackReset _ interruptCheckCounterFeedBackReset + 10]
	ifFalse: 
		[interruptCheckCounterFeedBackReset <= 1000 
			ifTrue: [interruptCheckCounterFeedBackReset _ 1000]
			ifFalse: [interruptCheckCounterFeedBackReset _ interruptCheckCounterFeedBackReset - 12]].

	interruptCheckCounter _ interruptCheckCounterFeedBackReset.  "reset the interrupt check counter"

	lastTick _ now.  "used to detect millisecond clock wrapping"

	signalLowSpace ifTrue: [
		signalLowSpace _ false.  "reset flag"
		sema _ (self splObj: TheLowSpaceSemaphore).
		sema = nilObj ifFalse: [self synchronousSignal: sema]].

	now >= nextPollTick ifTrue: [
		self ioProcessEvents.  "sets interruptPending if interrupt key pressed"
		nextPollTick _ now + 500].  "msecs to wait before next call to ioProcessEvents"

	interruptPending ifTrue: [
		interruptPending _ false.  "reset interrupt flag"
		sema _ (self splObj: TheInterruptSemaphore).
		sema = nilObj ifFalse: [self synchronousSignal: sema]].

	((nextWakeupTick ~= 0) and: [now >= nextWakeupTick]) ifTrue: [
		nextWakeupTick _ 0.  "reset timer interrupt"
		sema _ (self splObj: TheTimerSemaphore).
		sema = nilObj ifFalse: [self synchronousSignal: sema]].

	"signal any pending finalizations"
	pendingFinalizationSignals > 0 ifTrue:[
		sema _ self splObj: TheFinalizationSemaphore.
		(self fetchClassOf: sema) = (self splObj: ClassSemaphore) 
			ifTrue:[self synchronousSignal: sema].
		pendingFinalizationSignals _ 0.
	].

	"signal all semaphores in semaphoresToSignal" 
	(semaphoresToSignalCountA > 0 or: [semaphoresToSignalCountB > 0])
		ifTrue: [self signalExternalSemaphores].
