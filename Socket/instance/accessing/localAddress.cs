localAddress
	self waitForConnectionUntil: Socket standardDeadline.
	self isConnected ifFalse: [^ByteArray new: 4].
	^ self primSocketLocalAddress: socketHandle
