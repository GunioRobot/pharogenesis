isRunningInBrowser

	RunningInBrowser isNil
		ifTrue: [self determineIfRunningInBrowser].
	^RunningInBrowser