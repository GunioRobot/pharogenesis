selectOriginalCategoryForCurrentMethod
	"private - Select the message category for the current method. 
	 
	 Note:  This should only be called when somebody tries to save  
	 a method that they are modifying while ALL is selected. 
	 
	 Returns: true on success, false on failure."
	| aSymbol selectorName |
	aSymbol _ self categoryOfCurrentMethod.
	selectorName _ self selectedMessageName.
	(aSymbol notNil and: [aSymbol ~= ClassOrganizer allCategory])
		ifTrue: 
			[messageCategoryListIndex _ (self messageCategoryList indexOf: aSymbol).
			messageListIndex _ (self messageList indexOf: selectorName).
			self changed: #messageCategorySelectionChanged.
			self changed: #messageCategoryListIndex.	"update my selection"
			self changed: #messageList.
			self changed: #messageListIndex.
			^ true].
	^ false