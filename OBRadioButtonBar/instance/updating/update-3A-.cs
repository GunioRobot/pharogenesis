update: aSymbol
	aSymbol = getListSelector ifTrue: [self updateList. ^ self].
	aSymbol = getSelectionSelector ifTrue: [self updateSelection]