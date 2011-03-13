openSystemCategoryBrowser: aBrowser editString: aString 
	"Create and schedule a BrowserView with label 'System Category 
	Browser'. The view consists of five subviews, starting with the single 
	item list view of the currently selected system category of the 
	SystemOrganization. The initial text view part is a view of the characters 
	in aString."

	self openBrowserView: 
			(BrowserView systemCategoryBrowser: aBrowser editString: aString)
		label:
			'System Category Browser'