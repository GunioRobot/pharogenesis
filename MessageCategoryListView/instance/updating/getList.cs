getList 
	"Refer to the comment in BrowserListView|getList."

	model classCommentIndicated ifTrue: [^ Array new].
	singleItemMode
		ifTrue: [^Array with: model selectedMessageCategoryName asSymbol]
		ifFalse: [^model messageCategoryList]