initializeNetworkIfFail: failBlock
	"Initialize the network drivers. Do nothing if the network is already initialized. Evaluate the given block if network initialization fails, perhaps because this computer isn't currently connected to a network."

	NetNameResolver initializeNetwork