prepareToBeRunning
	self instantiatedUserScriptsDo:
		[:aScriptInstantiation | aScriptInstantiation prepareToBeRunning].