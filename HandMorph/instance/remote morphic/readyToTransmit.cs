readyToTransmit
	"Return true if all connections are ready to send."

	remoteConnections do: [:triple | (triple first) sendDone ifFalse: [^ false]].
	^ true
