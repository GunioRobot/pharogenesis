chooseChangeSetCategory
	"Present the user with a list of change-set-categories and let her choose one"

	|  cats aMenu result |
	self okToChange ifFalse: [^ self].
	Smalltalk isMorphic ifTrue: [^ self chooseChangeSetCategoryInMorphic].  "gives balloon help"

	cats _ ChangeSetCategories elementsInOrder.
	aMenu _ SelectionMenu
		labels: (cats collect: [:cat | cat categoryName])
		selections: cats.
	result _ aMenu startUp.
	result ifNotNil:
		[changeSetCategory _ result.
		self changed: #changeSetList.
		(self changeSetList includes: myChangeSet name) ifFalse:
			[self showChangeSet: (ChangeSorter changeSetNamed: self changeSetList first)].
		self changed: #relabel]