checkForInterrupts
	"Check for possible interrupts and handle one if necessary."

	| sema now index externalObjects semaClass |
	self inline: false.
	"Mask so same wrap as primitiveMillisecondClock"
	now _ self ioMSecs bitAnd: 16r1FFFFFFF.

	now < lastTick ifTrue: [
		"millisecond clock wrapped"
		nextPollTick _ now + (nextPollTick - lastTick).
		nextWakeupTick ~= 0
			ifTrue: [nextWakeupTick _ now + (nextWakeupTick - lastTick)]].
	lastTick _ now.  "used to detect millisecond clock wrapping"

	signalLowSpace ifTrue: [
		signalLowSpace _ false.  "reset flag"
		sema _ (self splObj: TheLowSpaceSemaphore).
		sema = nilObj ifFalse: [^ self synchronousSignal: sema]].

	now >= nextPollTick ifTrue: [
		self ioProcessEvents.  "sets interruptPending if interrupt key pressed"
		nextPollTick _ now + 500].  "msecs to wait before next call to ioProcessEvents"

	interruptPending ifTrue: [
		interruptPending _ false.  "reset interrupt flag"
		sema _ (self splObj: TheInterruptSemaphore).
		sema = nilObj ifFalse: [^ self synchronousSignal: sema]].

	((nextWakeupTick ~= 0) and: [now >= nextWakeupTick]) ifTrue: [
		nextWakeupTick _ 0.  "reset timer interrupt"
		sema _ (self splObj: TheTimerSemaphore).
		sema = nilObj ifFalse: [^ self synchronousSignal: sema]].

	"signal all semaphores in semaphoresToSignal" 
	semaphoresToSignalCount > 0 ifTrue: [
		externalObjects _ self splObj: ExternalObjectsArray.
		semaClass _ self splObj: ClassSemaphore.
		1 to: semaphoresToSignalCount do: [:i |
			index _ semaphoresToSignal at: i.
			sema _ self fetchPointer: index - 1 ofObject: externalObjects.
				"Note: semaphore indices are 1-based"
			(self fetchClassOf: sema) = semaClass
				ifTrue: [self synchronousSignal: sema]].
		semaphoresToSignalCount _ 0].
