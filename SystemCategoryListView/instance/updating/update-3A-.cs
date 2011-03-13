update: aSymbol

	aSymbol == #systemCategorySelectionChanged
		ifTrue: [self updateSystemCategorySelection. ^self].
	aSymbol == #systemCategoriesChanged
		ifTrue: [self updateSystemCategoryList. ^self]