update: aSymbol
	"What to do to the message list when Browser changes.
	If there is only one item, select and show it." 
	aSymbol == #messageSelectionChanged
		ifTrue: [self updateMessageSelection. ^self].

	(aSymbol == #systemCategorySelectionChanged) |
	(aSymbol == #editSystemCategories) |
	(aSymbol == #editClass) |
	(aSymbol == #editMessageCategories)
		ifTrue: [self resetAndDisplayView. ^self].

	(aSymbol == #messageCategorySelectionChanged) |
	(aSymbol == #messageListChanged) 
		ifTrue: [self updateMessageList. ^self].

	(aSymbol == #classSelectionChanged) ifTrue: [
		model messageCategoryListIndex = 1
			ifTrue: ["self updateMessageList." ^self]
			ifFalse: [self resetAndDisplayView. ^self]].