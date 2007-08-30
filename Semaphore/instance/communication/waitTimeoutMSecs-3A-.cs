waitTimeoutMSecs: anInteger
	"Wait on this semaphore for up to the given number of milliseconds, then timeout. It is up to the sender to determine the difference between the expected event and a timeout."

	| d |
	d := Delay timeoutSemaphore: self afterMSecs: (anInteger max: 0).
	[self wait] ensure:[d unschedule].
