messageCount
	| shouldClose |
	shouldClose _ popClient isConnected not.
	messageCount _ popClient messageCount.
	shouldClose
		ifTrue: [popClient close].
	lastConnectTime _ Time now.
	^messageCount