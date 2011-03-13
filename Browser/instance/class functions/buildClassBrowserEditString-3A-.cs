buildClassBrowserEditString: aString 
	"Create and schedule a new class browser for the current selection, if one 
	exists, with initial textual contents set to aString."

	| newBrowser myClass |
	classListIndex ~= 0 ifTrue: 
		[newBrowser _ Browser new.
		newBrowser systemCategoryListIndex: systemCategoryListIndex.
		newBrowser classListIndex: classListIndex.
		newBrowser metaClassIndicated: metaClassIndicated.

		myClass _ self selectedClassOrMetaClass.
		myClass notNil ifTrue: [
			Browser postOpenSuggestion: 
				(Array with: myClass with: self selectedMessageName)].

		BrowserView openClassBrowser: newBrowser editString: aString label: 'Class Browser: ', myClass name]