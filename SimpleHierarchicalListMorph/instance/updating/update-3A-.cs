update: aSymbol 

	aSymbol == getSelectionSelector ifTrue:
		[self selection: self getCurrentSelectionItem.
		^ self].
	aSymbol == getListSelector ifTrue: 
		[self list: self getList.
		^ self].
