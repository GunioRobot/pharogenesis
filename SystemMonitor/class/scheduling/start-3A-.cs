start: aMonitor
	self stop.
	ActiveMonitor _ aMonitor.
	ActiveClock _
		[[true] whileTrue:
			[ActiveMonitor display.
			(Delay forMilliseconds: MonitorDelay) wait]] newProcess.
	ActiveClock priority: Processor lowIOPriority.
	ActiveClock resume