initializeInterpreter: bytesToShift
	"Initialize Interpreter state before starting execution of a new image."

	interpreterProxy _ self sqGetInterpreterProxy.
	self dummyReferToProxy.
	self initializeObjectMemory: bytesToShift.
	self initCompilerHooks.
	
	activeContext	_ nilObj.
	theHomeContext	_ nilObj.
	method			_ nilObj.
	receiver		_ nilObj.
	messageSelector	_ nilObj.
	newMethod		_ nilObj.
	methodClass		_ nilObj.
	lkupClass		_ nilObj.
	receiverClass	_ nilObj.
	newNativeMethod		_ nilObj.

	self flushMethodCache.
	self loadInitialContext.
	self initialCleanup.

	interruptCheckCounter _ 0.
	interruptCheckCounterFeedBackReset _ 1000.
	interruptChecksEveryNms _ 1.
	nextPollTick _ 0.
	nextWakeupTick _ 0.
	lastTick _ 0.
	interruptKeycode _ 2094.  "cmd-."
	interruptPending _ false.
	semaphoresUseBufferA _ true.
	semaphoresToSignalCountA _ 0.
	semaphoresToSignalCountB _ 0.
	deferDisplayUpdates _ false.
	pendingFinalizationSignals _ 0.
