makeNewCategoryShowingClassChanges
	"Create a new, static change-set category, which will be populated entirely by change sets that have been manually placed in it"

	| catName aCategory clsName |
	clsName _ self selectedClass ifNotNil: [self selectedClass name ] ifNil: [''].
	clsName _ FillInTheBlank request: 'Which class?' initialAnswer: clsName.
	clsName isEmptyOrNil ifTrue: [^ self].
	catName _ ('Changes to ', clsName) asSymbol.
	(ChangeSetCategories includesKey: catName) ifTrue:
		[^ self inform: 'Sorry, there is already a category of that name'].

	aCategory _ ChangeSetCategoryWithParameters new categoryName: catName.
	aCategory membershipSelector: #changeSet:containsClass: ; parameters: { clsName }.
	ChangeSetCategories elementAt: catName put: aCategory.
	aCategory reconstituteList.
	self showChangeSetCategory: aCategory