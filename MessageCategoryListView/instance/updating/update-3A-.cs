update: aSymbol

	(aSymbol == #systemCategorySelectionChanged) |
	(aSymbol == #editSystemCategories)
		ifTrue: [self resetAndDisplayView. ^self].
	(aSymbol == #classSelectionChanged)
		ifTrue: [self getListAndDisplayView. ^self].
	(aSymbol == #messageCategorySelectionChanged)
		ifTrue:  [self moveSelectionBox: model messageCategoryListIndex. ^self]