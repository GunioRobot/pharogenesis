makeNewCategoryShowingClassChanges
	"Create a new, static change-set category, which will be populated entirely by change sets that have been manually placed in it"

	| catName aCategory clsName |
	clsName := self selectedClass ifNotNil: [self selectedClass name ] ifNil: [''].
	clsName := UIManager default request: 'Which class?' initialAnswer: clsName.
	clsName isEmptyOrNil ifTrue: [^ self].
	catName := ('Changes to ', clsName) asSymbol.
	(ChangeSetCategories includesKey: catName) ifTrue:
		[^ self inform: 'Sorry, there is already a category of that name'].

	aCategory := ChangeSetCategoryWithParameters new categoryName: catName.
	aCategory membershipSelector: #changeSet:containsClass: ; parameters: { clsName }.
	ChangeSetCategories elementAt: catName put: aCategory.
	aCategory reconstituteList.
	self showChangeSetCategory: aCategory