buildClassBrowserEditString: aString 
	"Create and schedule a new class browser for the current selection, with initial textual contents set to aString.  This is used specifically in spawning where a class is established but a method-category is not."

	| newBrowser  |
	newBrowser _ Browser new.
	newBrowser setClass: self selectedClassOrMetaClass selector: nil.
	newBrowser editSelection: #newMessage.
	Browser openBrowserView: (newBrowser openOnClassWithEditString: aString)
			label: 'Class Browser: ', self selectedClassOrMetaClass name
