startUp
	"Run the I/O process"
	self shutDown.
	self initialize.
	self primSetInputSemaphore: (Smalltalk registerExternalObject: inputSemaphore).
	inputProcess _ [self ioProcess] forkAt: Processor lowIOPriority.
	super startUp.
	Smalltalk isMorphic ifTrue:[self eventQueue: SharedQueue new].