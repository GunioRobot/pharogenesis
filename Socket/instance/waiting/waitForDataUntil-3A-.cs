waitForDataUntil: deadline
	"Wait up until the given deadline for data to arrive. Return true if data arrives by the deadline, false if not."

	| dataArrived |
	dataArrived _ self primSocketReceiveDataAvailable: socketHandle.
	[dataArrived not and:
	 [self isConnected and:
	 [Time millisecondClockValue < deadline]]] whileTrue: [
		semaphore waitTimeoutMSecs: (deadline - Time millisecondClockValue).
		dataArrived _ self primSocketReceiveDataAvailable: socketHandle].

	^ dataArrived
