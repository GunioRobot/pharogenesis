update: aSymbol

	(aSymbol == #systemCategorySelectionChanged) |
	(aSymbol == #editSystemCategories) |
	(aSymbol == #classListChanged)
		ifTrue:  [self updateClassList. ^self].
	(aSymbol == #classSelectionChanged)
		ifTrue: [self updateClassSelection. ^self]