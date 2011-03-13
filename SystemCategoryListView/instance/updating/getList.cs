getList 
	"Refer to the comment in BrowserListView|getList."

	| selectedSystemCategoryName |
	singleItemMode
		ifTrue: 
			[selectedSystemCategoryName _ model selectedSystemCategoryName.
			selectedSystemCategoryName == nil 
				ifTrue: [selectedSystemCategoryName _ '    '].
			^Array with: selectedSystemCategoryName asSymbol]
		ifFalse: [^model systemCategoryList]