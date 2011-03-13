isRunningAsBrowserPlugin
	(self privateCheckForBrowserPrimitives ~~ false)
		ifFalse: [^false].
	self new waitBrowserReadyFor: 1000 ifFail: [^false].
	^true