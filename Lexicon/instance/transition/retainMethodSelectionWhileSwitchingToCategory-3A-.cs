retainMethodSelectionWhileSwitchingToCategory: aCategoryName
	"retain method selection while switching the category-pane selection to show the category of the given name"

	| aSelectedName |
	aSelectedName _ self selectedMessageName.
	self categoryListIndex: (categoryList indexOf: aCategoryName ifAbsent: [^ self]).
	aSelectedName ifNotNil: [self selectWithinCurrentCategory: aSelectedName]
