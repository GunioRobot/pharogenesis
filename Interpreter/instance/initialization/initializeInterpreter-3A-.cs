initializeInterpreter: bytesToShift
	"Initialize Interpreter state before starting execution of a new image."

	self initializeObjectMemory: bytesToShift.
	self initBBOpTable.

	activeContext	_ nilObj.
	theHomeContext	_ nilObj.
	method			_ nilObj.
	receiver		_ nilObj.
	messageSelector	_ nilObj.
	newMethod		_ nilObj.

	self flushMethodCache.
	self loadInitialContext.
	interruptCheckCounter _ 0.
	nextPollTick _ 0.
	nextWakeupTick _ 0.
	lastTick _ 0.
	interruptKeycode _ 2094.  "cmd-."
	interruptPending _ false.
	semaphoresToSignalCount _ 0.
