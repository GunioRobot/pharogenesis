localAddress
	self waitForConnectionUntil: self class standardDeadline.
	self isConnected ifFalse: [^ByteArray new: 4].
	^self primSocketLocalAddress: socketHandle