initialize: aSocket

	transmissionError _ false.
	super initialize: aSocket.
	outputQueue _ SharedQueue new.
	extraUnsentBytes _ bytesInOutputQueue _ 0.
	socketWriterProcess _ [
		[self transmitQueueNext] whileTrue.
		socketWriterProcess _ nil.
		outputQueue _ nil.
		bytesInOutputQueue _ 0.
	] forkAt: Processor lowIOPriority.