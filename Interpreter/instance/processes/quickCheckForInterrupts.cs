quickCheckForInterrupts
	"Quick check for possible user or timer interrupts. Decrement a counter and only do a real check when counter reaches zero or when a low space or user interrupt is pending."
	"Note: Clients who set signalLowSpace or interruptPending should also set interruptCheckCounter to zero to get immediate results."
	"Note: Requires that instructionPointer and stackPointer be external."

	((interruptCheckCounter _ interruptCheckCounter - 1) <= 0) ifTrue: [
		interruptCheckCounter _ 1000.
		self checkForInterrupts.
	].
