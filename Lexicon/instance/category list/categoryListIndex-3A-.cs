categoryListIndex: anIndex
	"Set the category list index as indicated"

	| categoryName aList found existingSelector |
	existingSelector := self selectedMessageName.

	categoryListIndex := anIndex.
	anIndex > 0
		ifTrue:
			[categoryName := categoryList at: anIndex]
		ifFalse:
			[contents := nil].
	self changed: #categoryListIndex.

	found := false.
	#(	(viewedCategoryName		selectorsVisited)
		(queryCategoryName		selectorsRetrieved)) do:
			[:pair |
				categoryName = (self class perform: pair first)
					ifTrue:
						[aList := self perform: pair second.
						found := true]].
	found ifFalse:
		[aList := currentVocabulary allMethodsInCategory: categoryName forInstance: self targetObject ofClass: targetClass].
	categoryName = self class queryCategoryName ifFalse: [autoSelectString := nil].

	self initListFrom: aList highlighting: targetClass.

	messageListIndex := 0.
	self changed: #messageList.
	contents := nil.
	self contentsChanged.
	self selectWithinCurrentCategoryIfPossible: existingSelector.
	self adjustWindowTitle