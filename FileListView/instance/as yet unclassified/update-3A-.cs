update: aSymbol 
	aSymbol = #relabel ifTrue: [^ self].
	aSymbol == #fileList ifTrue: 
			[self list: model fileList.
			self displayView.
			^self].
	aSymbol == #fileListIndex ifTrue: 
			[self moveSelectionBox: model fileListIndex.
			^self]