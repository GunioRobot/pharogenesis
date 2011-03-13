primInterruptSemaphore: aSemaphore 
	"Primitive. Install the argument as the semaphore to be signalled whenever the user presses the interrupt key. The semaphore will be signaled once each time the interrupt key is pressed."
	interruptSemaphore _ aSemaphore.
	"backward compatibility: use the old primitive which is obsolete now"
	super primInterruptSemaphore: aSemaphore