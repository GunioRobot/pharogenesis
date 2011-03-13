primitiveResponse
	"Details: Since primitives can run for a long time, we must check to see if it is time to process a timer interrupt. However, on the Mac, the high-resolution millisecond clock is expensive to poll. Thus, we use a fast, low-resolution (1/60th second) clock to determine if the primitive took enough time to justify polling the high-resolution clock. Seems Byzantine, but Bob Arning showed that the performance of primitive-intensive code decreased substantially if there was another process waiting on a Delay.
	One other detail: If the primitive fails, we want to postpone the timer interrupt until just after the primitive failure code has been entered. This is accomplished by setting the interrupt check counter to zero, thus triggering a check for interrupts when activating the method containing the primitive."

	| timerPending startTime |
	timerPending _ nextWakeupTick ~= 0.
	timerPending ifTrue: [startTime _ self ioLowResMSecs].
	successFlag _ true.
	self dispatchOn: primitiveIndex in: PrimitiveTable.
	timerPending ifTrue: [
		(self ioLowResMSecs ~= startTime) ifTrue: [
			"primitive ran for more than a tick; check for possible timer interrupts"
			((self ioMSecs bitAnd: MillisecondClockMask) >= nextWakeupTick) ifTrue: [
				successFlag
					ifTrue: ["process the interrupt now"
							self checkForInterrupts]
					ifFalse: ["process the interrupt in primtive failure code"
							interruptCheckCounter _ 0]]]].
	^ successFlag
