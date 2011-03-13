buildClassBrowserEditString: aString 
	"Create and schedule a new class browser for the current selection, if one 
	exists, with initial textual contents set to aString."

	| newBrowser |
	self selectedClass ifNotNil:
		[newBrowser _ Browser new.
		newBrowser setClass: self selectedClassOrMetaClass selector: self selectedMessageName.
		Browser openBrowserView: (newBrowser openOnClassWithEditString: aString)
			label: 'Class Browser: ', self selectedClassOrMetaClass name]
