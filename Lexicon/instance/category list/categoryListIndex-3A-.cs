categoryListIndex: anIndex
	"Set the category list index as indicated"

	| categoryName aList found existingSelector |
	existingSelector _ self selectedMessageName.

	categoryListIndex _ anIndex.
	anIndex > 0
		ifTrue:
			[categoryName _ categoryList at: anIndex]
		ifFalse:
			[contents _ nil].
	self changed: #categoryListIndex.

	found _ false.
	#(	(viewedCategoryName		selectorsVisited)
		(queryCategoryName		selectorsRetrieved)) do:
			[:pair |
				categoryName = (self class perform: pair first)
					ifTrue:
						[aList _ self perform: pair second.
						found _ true]].
	found ifFalse:
		[aList _ currentVocabulary allMethodsInCategory: categoryName forInstance: self targetObject ofClass: targetClass].
	categoryName = self class queryCategoryName ifFalse: [autoSelectString _ nil].

	self initListFrom: aList highlighting: targetClass.

	messageListIndex _ 0.
	self changed: #messageList.
	contents _ nil.
	self contentsChanged.
	self selectWithinCurrentCategoryIfPossible: existingSelector.
	self adjustWindowTitle