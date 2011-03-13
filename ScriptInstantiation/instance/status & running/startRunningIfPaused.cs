startRunningIfPaused
	status == #paused ifTrue:
		[status _ #ticking]