removeContainedInClassCategories
	| matchExpression |
	myChangeSet removePreamble.
	matchExpression :=  FillInTheBlank request: 'Enter class category name (wildcard is ok)' initialAnswer: 'System-*'. 
	(SystemOrganization categories
		select: [:each | matchExpression match: each])
		do: [:eachCat | 
			| classNames | 
			classNames := SystemOrganization listAtCategoryNamed: eachCat.
			classNames
				do: [:eachClassName | 
					myChangeSet removeClassChanges: eachClassName.
					myChangeSet removeClassChanges: eachClassName , ' class'].
			self showChangeSet: myChangeSet]