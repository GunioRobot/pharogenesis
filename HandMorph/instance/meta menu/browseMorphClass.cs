browseMorphClass

	| mClass newBrowser |
	mClass _ argument class.
	newBrowser _ HierarchyBrowser new
		initHierarchyForClass: mClass
		meta: false.
	Browser openBrowserView: (newBrowser openSystemCatEditString: nil)
		label: mClass name, ' hierarchy'