updateSystemCategorySelection

	singleItemMode
		ifTrue: [self getListAndDisplayView]
		ifFalse: [self moveSelectionBox: model systemCategoryListIndex]