tearDown
	| systemNavigation |
	systemNavigation := SystemNavigation default.
	 systemNavigation browserClass: originalBrowserClass.
	 systemNavigation hierarchyBrowserClass: originalHierarchyBrowserClass.