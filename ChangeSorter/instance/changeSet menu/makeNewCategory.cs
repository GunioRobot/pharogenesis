makeNewCategory
	"Create a new, static change-set category, which will be populated entirely by change sets that have been manually placed in it"

	| catName aCategory |
	catName := UIManager default request: 'Please give the new category a name' initialAnswer: ''.
	catName isEmptyOrNil ifTrue: [^ self].
	catName := catName asSymbol.
	(ChangeSetCategories includesKey: catName) ifTrue:
		[^ self inform: 'Sorry, there is already a category of that name'].

	aCategory := StaticChangeSetCategory new categoryName: catName.
	ChangeSetCategories elementAt: catName put: aCategory.
	aCategory addChangeSet: myChangeSet.
	self showChangeSetCategory: aCategory