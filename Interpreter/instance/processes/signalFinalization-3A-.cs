signalFinalization: weakReferenceOop
	"If it is not there already, record the given semaphore index in the list of semaphores to be signaled at the next convenient moment. Set the interruptCheckCounter to zero to force a real interrupt check as soon as possible."

	interruptCheckCounter _ 0.
	pendingFinalizationSignals _ pendingFinalizationSignals + 1.