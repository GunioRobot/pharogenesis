openClassBrowser: aBrowser editString: aString label: aLabel
	"Create and schedule a BrowserView with the specified window title.   The view  consists of four subviews, starting with the list view of classes in the  SystemOrganization's currently selected system category. The initial text  view part is a view of the characters in aString."

	self openBrowserView: (BrowserView classBrowser: aBrowser editString: aString)
		label: aLabel