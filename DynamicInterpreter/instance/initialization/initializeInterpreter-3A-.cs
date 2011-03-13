initializeInterpreter: bytesToShift
	"Initialize Interpreter state before starting execution of a new image."
	self inline: false.
	self initializeObjectMemory: bytesToShift.
	self initBBOpTable.

	messageSelector			_ nilObj.
	newReceiver			_ nilObj.
	newMethod				_ nilObj.
	newTranslatedMethod	_ nilObj.

	pseudoReceiver			_ 0.

	self initializeTranslator.

	self initMethodCache.
	self loadInitialContext.
	interruptCheckCounter _ 0.
	nextPollTick _ 0.
	nextWakeupTick _ 0.
	lastTick _ 0.
	interruptKeycode _ 2094.  "cmd-."
	interruptPending _ false.
	semaphoresToSignalCount _ 0.
	deferDisplayUpdates _ false.
