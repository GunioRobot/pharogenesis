monitorProcessPeriod: secs sampleRate: msecs
	self stopMonitoring.

	watcher _ [ [ | promise |
		promise _ Processor tallyCPUUsageFor: secs every: msecs.
		tally _ promise value.
		promise _ nil.
		self findThePig.
	] repeat ] forkAt: Processor highestPriority.
	Processor yield 