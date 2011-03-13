updateClassSelection

	singleItemMode 
		ifTrue: [self getListAndDisplayView]
		ifFalse: [self moveSelectionBox: model classListIndex]