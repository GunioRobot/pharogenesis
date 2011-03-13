addSystemCategory
	"Prompt for a new category name and add it before the
	current selection, or at the end if no current selection"
	| oldIndex newName |
	self okToChange ifFalse: [^ self].
	oldIndex _ systemCategoryListIndex.
	newName _ self
		request: 'Please type new category name'
		initialAnswer: 'Category-Name'.
	newName isEmpty
		ifTrue: [^ self]
		ifFalse: [newName _ newName asSymbol].
	systemOrganizer
		addCategory: newName
		before: (systemCategoryListIndex = 0
				ifTrue: [nil]
				ifFalse: [self selectedSystemCategoryName]).
	self changed: #systemCategoriesChanged.
	self systemCategoryListIndex:
		(oldIndex = 0
			ifTrue: [systemOrganizer categories size]
			ifFalse: [oldIndex])