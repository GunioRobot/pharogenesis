update: aSymbol

	aSymbol == #inspectObject
		ifTrue: 
			[self list: model fieldList.
			selection _ model selectionIndex.
			self displayView].
	aSymbol == #selection ifTrue: [self moveSelectionBox: model selectionIndex]