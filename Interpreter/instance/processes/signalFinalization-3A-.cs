signalFinalization: weakReferenceOop
	"If it is not there already, record the given semaphore index in the list of semaphores to be signaled at the next convenient moment. Force a real interrupt check as soon as possible."

	self forceInterruptCheck.
	pendingFinalizationSignals _ pendingFinalizationSignals + 1.