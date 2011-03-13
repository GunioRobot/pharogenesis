cpuWatcherEnabled
	^ self
		valueOfFlag: #cpuWatcherEnabled
		ifAbsent: [false]