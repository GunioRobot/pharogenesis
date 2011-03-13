startRunning
	costume startStepping.
	self instantiatedUserScriptsDo:
		[:aScript | aScript startRunningIfPaused]