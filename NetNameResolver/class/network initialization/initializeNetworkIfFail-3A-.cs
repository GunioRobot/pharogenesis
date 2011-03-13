initializeNetworkIfFail: errorBlock
	"Initialize the network drivers and record the semaphore to be used by the resolver. Do nothing if the network is already initialized. Evaluate the given block if network initialization fails."
	"NetNameResolver initializeNetworkIfFail: [self error: 'network initialization failed']"

	| semaIndex result |
	self resolverStatus = ResolverUninitialized
		ifFalse: [
			LastContact _ Time totalSeconds.  HaveNetwork _ true.
			^ self].  "network is already initialized"

	LastContact _ Time totalSeconds.  HaveNetwork _ false.	"in case abort"
	ResolverSemaphore _ Semaphore new.
	semaIndex _ Smalltalk registerExternalObject: ResolverSemaphore.

	Utilities informUser:
'Initializing the network drivers; this may
take up to 30 seconds and can''t be interrupted'
		during: [result _ self primInitializeNetwork: semaIndex].
	Display repaintMorphicDisplayNow.  "take the informer down"

	"result is nil if network initialization failed, self if it succeeds"
	result ifNil: [errorBlock value]
		ifNotNil: [HaveNetwork _ true].
