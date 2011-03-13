primSignal: aSemaphore atMilliseconds: aSmallInteger
	"Signal the semaphore when the millisecond clock reaches the value of the second argument. Fail if the first argument is neither a Semaphore nor nil. Essential. See Object documentation whatIsAPrimitive."

	| guardianDelay |
	<primitive: 136>
	"VM code actually only fails if the time parameter is not a SmallInteger value"
	aSmallInteger isInteger ifFalse:["somebody messed up badly and we can't do much about it"
		aSemaphore ifNotNil: [
			ActiveDelay _ nil.
			aSemaphore signal. "Prevent an image crash"].
	^self primitiveError: 'primSignal:atMilliseconds: failed because of a non-Integer resumption time parameter. The Semaphore has been signalled as a best guess of the right thing to do'].

	"So now we feel fairly sure that the aSmallInteger resumption time is actually a large integer and we need to just wait some more. To make the system do that we need a fake Delay and a reasonable resumption time to feed to the VM. A decent value is SmallInteger maxVal since the VM handles correlating that sort of largish value and clock wrapping.
	First though we return the problem Delay to the queue"
	SuspendedDelays add: ActiveDelay.
	"Now we want a Delay set to fire and do nothing"
	guardianDelay _ self guardianDelay.
	guardianDelay activate
	