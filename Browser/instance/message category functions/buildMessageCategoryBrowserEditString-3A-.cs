buildMessageCategoryBrowserEditString: aString 
	"Create and schedule a message category browser for the currently 
	selected	 message category. The initial text view contains the characters 
	in aString."

	| newBrowser |
	messageCategoryListIndex ~= 0
		ifTrue: 
			[newBrowser _ Browser new.
			newBrowser systemCategoryListIndex: systemCategoryListIndex.
			newBrowser classListIndex: classListIndex.
			newBrowser metaClassIndicated: metaClassIndicated.
			newBrowser messageCategoryListIndex: messageCategoryListIndex.
			BrowserView openMessageCategoryBrowser: newBrowser editString: aString]