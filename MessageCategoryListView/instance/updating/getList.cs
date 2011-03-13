getList 
	"Refer to the comment in BrowserListView|getList."

	singleItemMode
		ifTrue: [^Array with: model selectedMessageCategoryName asSymbol]
		ifFalse: [^model messageCategoryList]