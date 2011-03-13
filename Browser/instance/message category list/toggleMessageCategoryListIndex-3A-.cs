toggleMessageCategoryListIndex: anInteger 
	"If the currently selected message category index is anInteger, deselect 
	the category. Otherwise select the category whose index is anInteger."

	self messageCategoryListIndex: 
		(messageCategoryListIndex = anInteger
			ifTrue: [0]
			ifFalse: [anInteger])