waitForSendDoneUntil: deadline
	"Wait up until the given deadline for the current send operation to complete. Return true if it completes by the deadline, false if not."

	| sendDone |
	sendDone _ self primSocketSendDone: socketHandle.
	[sendDone not and:
	 [self isConnected and:
	 [Time millisecondClockValue < deadline]]] whileTrue: [
		semaphore waitTimeoutMSecs: (deadline - Time millisecondClockValue).
		sendDone _ self primSocketSendDone: socketHandle].

	^ sendDone
