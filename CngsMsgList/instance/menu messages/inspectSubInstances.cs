inspectSubInstances
	controller controlTerminate.
	self classAndSelectorDo:
		[:cl :sel |  cl theNonMetaClass inspectSubInstances].
	controller controlInitialize
