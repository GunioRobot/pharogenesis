addCategory
	"Prompt for a new category name and add it before the
	current selection, or at the end if no current selection"
	| oldIndex newName |
	self okToChange ifFalse: [^ self].
	classListIndex = 0 ifTrue: [^ self].
	oldIndex _ messageCategoryListIndex.
	newName _ self
		request: 'Please type new category name'
		initialAnswer: 'category name'.
	newName isEmpty
		ifTrue: [^ self]
		ifFalse: [newName _ newName asSymbol].
	self classOrMetaClassOrganizer
		addCategory: newName
		before: (messageCategoryListIndex = 0
				ifTrue: [nil]
				ifFalse: [self selectedMessageCategoryName]).
	self changed: #messageCategoryList.
	self messageCategoryListIndex:
		(oldIndex = 0
			ifTrue: [self classOrMetaClassOrganizer categories size]
			ifFalse: [oldIndex]).
	self changed: #messageCategoryList.
