spawn: aString 
	"Create and schedule a spawned message category browser for the currently selected message category.  The initial text view contains the characters in aString.  In the spawned browser, preselect the current selector (if any) as the going-in assumption, though upon acceptance this will often change"

	| newBrowser aCategory aClass |
	(aClass := self selectedClassOrMetaClass) isNil ifTrue:
		[^ aString isEmptyOrNil ifFalse: [(Workspace new contents: aString) openLabel: 'spawned workspace']].

	(aCategory := self categoryOfCurrentMethod)
		ifNil:
			[self buildClassBrowserEditString: aString]
		ifNotNil:
			[newBrowser := Browser new setClass: aClass selector: self selectedMessageName.
			self suggestCategoryToSpawnedBrowser: newBrowser.
			Browser openBrowserView: (newBrowser openMessageCatEditString: aString)
		label: 'category "', aCategory, '" in ', 
				newBrowser selectedClassOrMetaClassName]