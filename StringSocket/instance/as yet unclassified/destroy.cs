destroy

	socketWriterProcess ifNotNil: [socketWriterProcess terminate. socketWriterProcess _ nil].
	outputQueue _ nil.
	bytesInOutputQueue _ 0.
	socket ifNotNil: [socket destroy. socket _ nil.].
