browseMorphClass

	| mClass newBrowser view |
	mClass _ argument class.

	"Use following to get a simple browser:
	Browser newOnClass: mClass."

	newBrowser _ HierarchyBrowser new
		initHierarchyForClass: mClass
		meta: false.
	view _ BrowserView systemCategoryBrowser: newBrowser editString: nil.
	Browser postOpenSuggestion: (Array with: mClass with: nil).
	BrowserView openBrowserView: view
		label: mClass name, ' hierarchy'