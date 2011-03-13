openBrowserEditString: aString 
	"Create and schedule a BrowserView with label 'System Browser'. The 
	view consists of five subviews, starting with the list view of system 
	categories of SystemOrganization. The initial text view part is a view of 
	the characters in aString."

	self openBrowserView: (self browser: Browser new editString: aString)
		label: 'System Browser'