startUp
	"Run the I/O process"
	self initialize.
	self
		primSetInputSemaphore: (Smalltalk registerExternalObject: inputSemaphore).
	super startUp.
	self installEventTickler.
	UIManager default onEventSensorStartup: self..
	"Attempt to discover whether the input semaphore is actually being
	signaled. "
	hasInputSemaphore := false.
	inputSemaphore initSignals