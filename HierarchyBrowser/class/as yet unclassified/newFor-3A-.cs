newFor: aClass
	"Open a new HierarchyBrowser on the given class"
	|  newBrowser |
	newBrowser _ HierarchyBrowser new initHierarchyForClass: aClass.
	Browser openBrowserView: (newBrowser openSystemCatEditString: nil)
		label: aClass theNonMetaClass name, ' hierarchy'

"HierarchyBrowser newFor: Boolean"