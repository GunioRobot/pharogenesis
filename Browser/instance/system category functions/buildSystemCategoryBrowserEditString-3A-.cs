buildSystemCategoryBrowserEditString: aString 
	"Create and schedule a new system category browser with initial textual 
	contents set to aString."

	| newBrowser |
	systemCategoryListIndex > 0
		ifTrue: 
			[newBrowser _ Browser new.
			newBrowser systemCategoryListIndex: systemCategoryListIndex.
			BrowserView openSystemCategoryBrowser: newBrowser editString: aString]