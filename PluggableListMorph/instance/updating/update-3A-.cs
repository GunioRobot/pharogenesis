update: aSymbol 
	"Refer to the comment in View|update:."

	aSymbol == getListSelector ifTrue: 
		[self list: self getList.
		^ self].
	aSymbol == getIndexSelector ifTrue:
		[self selectionIndex: self getCurrentSelectionIndex.
		^ self].
