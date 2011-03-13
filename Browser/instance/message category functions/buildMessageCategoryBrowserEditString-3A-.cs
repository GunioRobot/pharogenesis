buildMessageCategoryBrowserEditString: aString 
	"Create and schedule a message category browser for the currently 
	selected	 message category. The initial text view contains the characters 
	in aString."
	"wod 6/24/1998: set newBrowser classListIndex so that it works whether the
	receiver is a standard or a Hierarchy Browser."

	| newBrowser |
	messageCategoryListIndex ~= 0
		ifTrue: 
			[newBrowser := Browser new.
			newBrowser systemCategoryListIndex: systemCategoryListIndex.
			newBrowser classListIndex: (newBrowser classList indexOf: self selectedClassName).
			newBrowser metaClassIndicated: metaClassIndicated.
			newBrowser messageCategoryListIndex: messageCategoryListIndex.
			newBrowser messageListIndex: messageListIndex.
			self class openBrowserView: (newBrowser openMessageCatEditString: aString)
				label: 'Message Category Browser (' , 
						newBrowser selectedClassOrMetaClassName , ')']