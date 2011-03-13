remoteAddress

	self isConnected ifFalse: [^nil].
	^socket remoteAddress