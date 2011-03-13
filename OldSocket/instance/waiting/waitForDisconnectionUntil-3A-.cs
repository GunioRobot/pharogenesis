waitForDisconnectionUntil: deadline
	"Wait up until the given deadline for the the connection to be broken. Return true if it is broken by the deadline, false if not."
	"Note: The client should know the the connect is really going to be closed (e.g., because he has called 'close' to send a close request to the other end) before calling this method.
JMM 00/5/17 note that other end can close which will terminate wait"

	| extraBytes status |
	extraBytes _ 0.
	status _ self primSocketConnectionStatus: socketHandle.
	[((status = Connected) or: [(status = ThisEndClosed)]) and:
	 [Time millisecondClockValue < deadline]] whileTrue: [
		self dataAvailable
			ifTrue: [extraBytes _ extraBytes + self discardReceivedData].
		semaphore waitTimeoutMSecs: (deadline - Time millisecondClockValue).
		status _ self primSocketConnectionStatus: socketHandle].

	extraBytes > 0
		ifTrue: [self inform: 'Discarded ', extraBytes printString, ' bytes while closing connection.'].

	^ status ~= Connected
