disconnect
	self isConnected ifTrue: [
		Transcript show: 'disconnecting from ', hostname.
		socket disconnect ].