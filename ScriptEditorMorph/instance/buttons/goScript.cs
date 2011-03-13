goScript
	self scriptInstantiation status: #ticking.
	self install.
	self playerScripted costume startStepping.
	self color: self colorWhenRunning.

	playerScripted startRunningScripts