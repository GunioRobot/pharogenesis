openBrowser
	"Create and schedule a BrowserView with label 'System Browser'. The 
	view consists of five subviews, starting with the list view of system 
	categories of SystemOrganization. The initial text view part is empty."

	Browser openBrowserView: (Browser new openEditString: nil)
			label: 'System Browser'

