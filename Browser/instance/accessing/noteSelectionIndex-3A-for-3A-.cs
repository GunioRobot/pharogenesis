noteSelectionIndex: anInteger for: aSymbol
	aSymbol == #systemCategoryList
		ifTrue:
			[systemCategoryListIndex _ anInteger].
	aSymbol == #classList
		ifTrue:
			[classListIndex _ anInteger].
	aSymbol == #messageCategoryList
		ifTrue:
			[messageCategoryListIndex _ anInteger].
	aSymbol == #messageList
		ifTrue:
			[messageListIndex _ anInteger].