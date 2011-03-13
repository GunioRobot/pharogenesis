update: aSymbol

	aSymbol == #contextStackIndex
		ifTrue: [self moveSelectionBox: model contextStackIndex].
	aSymbol == #contextStackList
		ifTrue: 
			[self list: model contextStackList.
			self displayView].
	aSymbol == #notChanged ifTrue: [self flash]