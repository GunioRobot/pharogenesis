newFor: aClass labeled: aLabel
	"Open a new HierarchyBrowser on the given class, using aLabel as the window title."

	|  newBrowser |
	newBrowser _ HierarchyBrowser new initHierarchyForClass: aClass.
	Browser openBrowserView: (newBrowser openSystemCatEditString: nil)
		label: aLabel

"HierarchyBrowser newFor: Boolean labeled: 'Testing'"