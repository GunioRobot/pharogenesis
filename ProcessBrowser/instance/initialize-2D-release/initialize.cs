initialize
	methodText _ ''.
	stackListIndex _ 0.
	searchString _ ''.
	lastUpdate _ 0.
	startedCPUWatcher _ Preferences cpuWatcherEnabled and: [ self startCPUWatcher ].
	self updateProcessList; processListIndex: 1