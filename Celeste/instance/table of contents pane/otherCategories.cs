otherCategories
	"Prompt the user with a menu of all other categories in which the currently selected message appears. If the user chooses a category from this menu, go to that category."

	| otherCategories choice |
	otherCategories _
		(mailDB categoriesThatInclude: currentMsgID) asOrderedCollection.
	otherCategories remove: currentCategory ifAbsent: [].
	(otherCategories isEmpty) ifTrue: [^self].
	choice _ (CustomMenu selections: otherCategories) startUp.
	choice = nil ifFalse: [self setCategory: choice].