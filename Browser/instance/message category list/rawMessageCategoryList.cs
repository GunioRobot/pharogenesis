rawMessageCategoryList
	^ classListIndex = 0
		ifTrue: [Array new]
		ifFalse: [self classOrMetaClassOrganizer categories]