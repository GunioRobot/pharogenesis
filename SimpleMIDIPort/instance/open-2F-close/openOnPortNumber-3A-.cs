openOnPortNumber: portNum
	"Open this MIDI port on the given port number."

	self close.
	portNumber _ portNum.
	accessSema _ Semaphore forMutualExclusion.
	self ensureOpen.
