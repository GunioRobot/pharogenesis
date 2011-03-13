renameCategory
	"Obtain a new name for the category and, if acceptable, apply it"

	| catName oldName |
	self changeSetCategory acceptsManualAdditions ifFalse:
		[^ self inform: 'sorry, you can only rename manually-added categories.'].

	catName := UIManager default request: 'Please give the new category a name' initialAnswer:  (oldName := changeSetCategory categoryName).
	catName isEmptyOrNil ifTrue: [^ self].
	(catName := catName asSymbol) = oldName ifTrue: [^ self inform: 'no change.'].
	(ChangeSetCategories includesKey: catName) ifTrue:
		[^ self inform: 'Sorry, there is already a category of that name'].

	changeSetCategory categoryName: catName.
	ChangeSetCategories removeElementAt: oldName.
	ChangeSetCategories elementAt: catName put: changeSetCategory.

	self update