signalSemaphoreWithIndex: index
	"If it is not there already, record the given semaphore index in the list of semaphores to be signaled at the next convenient moment. Set the interruptCheckCounter to zero to force a real interrupt check as soon as possible."

	index <= 0 ifTrue: [^ nil].  "bad index; ignore it"

	interruptCheckCounter _ 0.
	1 to: semaphoresToSignalCount do: [:i |
		(semaphoresToSignal at: i) = index ifTrue: [^ nil]].

	semaphoresToSignalCount < SemaphoresToSignalSize ifTrue: [
		semaphoresToSignalCount _ semaphoresToSignalCount + 1.
		semaphoresToSignal at: semaphoresToSignalCount put: index].
