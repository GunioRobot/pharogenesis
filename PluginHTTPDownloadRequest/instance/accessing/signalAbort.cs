signalAbort
	fileStream ifNotNil: [
		fileStream close].
	fileStream _ nil.
	super signalAbort.