makeNewCategory
	"Create a new, static change-set category, which will be populated entirely by change sets that have been manually placed in it"

	| catName aCategory |
	catName _ FillInTheBlank request: 'Please give the new category a name' initialAnswer: ''.
	catName isEmptyOrNil ifTrue: [^ self].
	catName _ catName asSymbol.
	(ChangeSetCategories includesKey: catName) ifTrue:
		[^ self inform: 'Sorry, there is already a category of that name'].

	aCategory _ StaticChangeSetCategory new categoryName: catName.
	ChangeSetCategories elementAt: catName put: aCategory.
	aCategory addChangeSet: myChangeSet.
	self showChangeSetCategory: aCategory