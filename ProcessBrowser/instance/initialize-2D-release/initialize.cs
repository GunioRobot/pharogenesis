initialize
	methodText := ''.
	stackListIndex := 0.
	searchString := ''.
	lastUpdate := 0.
	startedCPUWatcher := Preferences cpuWatcherEnabled and: [ self startCPUWatcher ].
	self updateProcessList; processListIndex: 1