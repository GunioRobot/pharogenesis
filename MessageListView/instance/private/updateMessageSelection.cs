updateMessageSelection

	singleItemMode
		ifTrue: [self getListAndDisplayView] 
		ifFalse: [self moveSelectionBox: model messageListIndex]