stopMonitoring
	watcher ifNotNil: [
		ProcessBrowser terminateProcess: watcher.
		watcher _ nil.
	]