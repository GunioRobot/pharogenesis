browseAllClasses
	"Create and schedule a new browser on all classes alphabetically."
	| newBrowser view |
	newBrowser _ HierarchyBrowser new initAlphabeticListing.
	BrowserView openBrowserView: (BrowserView systemCategoryBrowser: newBrowser editString: nil)
		label: 'All Classes Alphabetically'