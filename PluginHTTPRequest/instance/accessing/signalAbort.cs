signalAbort
	fileStream ifNotNil: [
		(fileStream respondsTo: #close) ifTrue:[fileStream close]].
	fileStream _ nil.
	super signalAbort.