currentWatcherProcess
	^CurrentCPUWatcher ifNotNil: [ CurrentCPUWatcher watcherProcess ]
