tocEntryList
	currentCategory isNil
		ifTrue: [self initializeTocLists].
	self tocLists == nil
		ifTrue: [self initializeTocLists].
	^ self tocLists