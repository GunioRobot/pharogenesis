openMessageCategoryBrowser: aBrowser editString: aString 
	"Create and schedule a BrowserView with label 'Message Category 
	Browser' followed by the name of the selected class or metaclass. The 
	view consists of three subviews, starting with the list view of message 
	categories in the System Organization's currently selected class. The 
	initial text view part is a view of the characters in aString."

	self openBrowserView: 
			(BrowserView messageCategoryBrowser: aBrowser editString: aString)
		label: 
			'Message Category Browser (' , aBrowser selectedClassOrMetaClassName , ')'