inspectInstances
	controller controlTerminate.
	self classAndSelectorDo:
		[:cl :sel |  cl theNonMetaClass inspectAllInstances].
	controller controlInitialize
