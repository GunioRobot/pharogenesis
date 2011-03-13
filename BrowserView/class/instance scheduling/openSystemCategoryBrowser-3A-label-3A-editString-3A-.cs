openSystemCategoryBrowser: aBrowser label: aLabel editString: aString 
	"Create and schedule a BrowserView with label 'System Category 
	Browser'. The view consists of five subviews, starting with the single 
	item list view of the currently selected system category of the 
	SystemOrganization. The initial text view part is a view of the characters 
	in aString.
	7/13/96 sw: created this variant in which the caller can specifiy the window title"

	self openBrowserView: (BrowserView systemCategoryBrowser: aBrowser editString: aString)
		label: aLabel