selectedMessageCategoryName
	"Answer the name of the selected message category, if any. Answer nil 
	otherwise."

	messageCategoryListIndex = 0 ifTrue: [^nil].
	^self messageCategoryList at: messageCategoryListIndex