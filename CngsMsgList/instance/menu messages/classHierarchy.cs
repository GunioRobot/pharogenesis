classHierarchy
	self classAndSelectorDo:
		[:cl :sel |  
		Utilities spawnHierarchyForClass: cl selector: sel].
	controller controlInitialize