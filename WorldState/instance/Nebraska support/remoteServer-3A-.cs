remoteServer: aNebraskaServer
	remoteServer ifNotNil:[remoteServer destroy].
	remoteServer _ aNebraskaServer.
	self canvas: nil.