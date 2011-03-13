messageList
	"Answer an Array of the message selectors of the currently selected 
	message category. Otherwise, answer a new empty Array."

	messageCategoryListIndex = 0
		ifTrue: [^Array new]
		ifFalse: [^self classOrMetaClassOrganizer 
					listAtCategoryNumber: messageCategoryListIndex]