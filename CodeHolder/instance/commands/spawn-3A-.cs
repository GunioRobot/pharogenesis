spawn: aString 
	"Create and schedule a spawned message category browser for the currently selected message category.  The initial text view contains the characters in aString.  In the spawned browser, preselect the current selector (if any) as the going-in assumption, though upon acceptance this will often change"

	| newBrowser aCategory aClass |
	(aClass _ self selectedClassOrMetaClass) isNil ifTrue:
		[^ aString isEmptyOrNil ifFalse: [(Workspace new contents: aString) openLabel: 'spawned workspace']].

	(aCategory _ self categoryOfCurrentMethod)
		ifNil:
			[self buildClassBrowserEditString: aString]
		ifNotNil:
			[newBrowser _ Browser new setClass: aClass selector: self selectedMessageName.
			newBrowser setOriginalCategoryIndexForCurrentMethod.
			Browser openBrowserView: (newBrowser openMessageCatEditString: aString)
		label: 'category "', aCategory, '" in ', 
				newBrowser selectedClassOrMetaClassName]