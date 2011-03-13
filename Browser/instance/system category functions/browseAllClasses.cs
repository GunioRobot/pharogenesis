browseAllClasses
	"Create and schedule a new browser on all classes alphabetically."
	| newBrowser |
	newBrowser := HierarchyBrowser new initAlphabeticListing.
	self class openBrowserView: (newBrowser openSystemCatEditString: nil)
		label: 'All Classes Alphabetically'