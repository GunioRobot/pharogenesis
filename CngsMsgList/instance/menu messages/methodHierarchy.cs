methodHierarchy
	self classAndSelectorDo:
		[:cl :sel |  
		Utilities methodHierarchyBrowserForClass: cl selector: sel].
	controller controlInitialize