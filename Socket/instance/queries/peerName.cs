peerName
	"Return the name of the host I'm connected to."

	^NetNameResolver nameForAddress: (self primSocketRemoteAddress: socketHandle) timeout: 60