localPort
	self waitForConnectionUntil: Socket standardDeadline.
	self isConnected ifFalse: [^0 ].
	^ self primSocketLocalPort: socketHandle
