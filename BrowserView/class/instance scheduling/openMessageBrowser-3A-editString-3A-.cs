openMessageBrowser: aBrowser editString: aString 
	"Create and schedule a BrowserView with label 'Message Browser' 
	followed by the name of the selected class or metaclass. The view 
	consists of two subviews, starting with the list view of message selectors 
	in the System Organization's currently selected category. The initial text 
	view part is a view of the characters in aString."

	self openBrowserView: 
			(BrowserView messageBrowser: aBrowser editString: aString)
		label: aBrowser selectedClassOrMetaClassName , ' ' , aBrowser selectedMessageName