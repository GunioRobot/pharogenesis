selectOriginalCategoryForCurrentMethod
	"private - Select the message category for the current method. 
	 
	 Note:  This should only be called when somebody tries to save  
	 a method that they are modifying while ALL is selected. 
	 
	 Returns: true on success, false on failure."
	| aSymbol |
	aSymbol _ self categoryOfCurrentMethod.
	(aSymbol notNil and: [aSymbol ~= ClassOrganizer allCategory])
		ifTrue: 
			[self selectMessageCategoryNamed: aSymbol.
			^ true].
	^ false