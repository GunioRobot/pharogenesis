update: aSymbol
	"What to do to the message list when Browser changes. If there is only one item, select and show it.
	 : as part of adding a new feature that was subsequently removed, simplified the code here enough to justify using it"

	aSymbol == #messageSelectionChanged
		ifTrue: [^ self updateMessageSelection].

	(#(systemCategorySelectionChanged editSystemCategories editClass editMessageCategories) includes: aSymbol)
		ifTrue: [^ self resetAndDisplayView].

	(aSymbol == #messageCategorySelectionChanged) | (aSymbol == #messageListChanged) 
		ifTrue: [^ self updateMessageList.].

	(aSymbol == #classSelectionChanged) ifTrue:
		[model messageCategoryListIndex = 1
			ifTrue: ["self updateMessageList."]
			ifFalse: [^ self resetAndDisplayView]]