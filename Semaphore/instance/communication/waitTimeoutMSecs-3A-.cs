waitTimeoutMSecs: anInteger
	"Wait on this semaphore for up to the given number of milliseconds, then timeout. It is up to the sender to determine the difference between the expected event and a timeout."

	| waitingProcess wakeupProcess |
	waitingProcess _ Processor activeProcess.
	wakeupProcess _
		[(Delay forMilliseconds: (anInteger max: 0)) wait.
		self resumeProcess: waitingProcess] fork.

	self wait.
	wakeupProcess terminate.