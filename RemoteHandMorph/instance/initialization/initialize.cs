initialize

	super initialize.
	remoteWorldExtent _ 100@100.  "initial guess"
	socket _ nil.
	waitingForConnection _ false.
	receiveBuffer _ ''.
	sendState _ #unconnected.