localPort
	self waitForConnectionUntil: self class standardDeadline.
	self isConnected ifFalse: [^0].
	^self primSocketLocalPort: socketHandle