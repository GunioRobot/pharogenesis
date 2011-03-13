initPortNumber: anInteger queueLength: queueLength
	"Private! Initialize the receiver to listen on the given port number. Up to queueLength connections will be queued."

	portNumber _ anInteger.
	maxQueueLength _ queueLength.
	connections _ OrderedCollection new.
	accessSema _ Semaphore forMutualExclusion.
	socket _ nil.
	process _ [self listenLoop] newProcess.
	process priority: Processor highIOPriority.
	process resume.
