initializeNetwork
	"Initialize the network drivers and record the semaphore to be used by the resolver. Do nothing if the network is already initialized. Evaluate the given block if network initialization fails."
	"NetNameResolver initializeNetwork"

	| semaIndex |
	self resolverStatus = ResolverUninitialized
		ifFalse: [^HaveNetwork _ true].  "network is already initialized"

	HaveNetwork _ false.	"in case abort"
	ResolverSemaphore _ Semaphore new.
	semaIndex _ Smalltalk registerExternalObject: ResolverSemaphore.

	"result is nil if network initialization failed, self if it succeeds"
	(self primInitializeNetwork: semaIndex)
		ifNil: [NoNetworkError signal: 'failed network initialization']
		ifNotNil: [HaveNetwork _ true].
