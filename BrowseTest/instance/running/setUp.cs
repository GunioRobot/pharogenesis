setUp
	| systemNavigation |
	systemNavigation := SystemNavigation default.
	originalBrowserClass := systemNavigation browserClass.
	originalHierarchyBrowserClass := systemNavigation hierarchyBrowserClass.
	
	 systemNavigation browserClass: nil.
	 systemNavigation hierarchyBrowserClass: nil.
	
	