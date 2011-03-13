findClassesForCategories: aCollection
	| items |
	aCollection isEmpty 
		ifTrue: [ ^ self baseClass withAllSubclasses ].
	items := aCollection gather: [ :category |
		((Smalltalk organization listAtCategoryNamed: category)
			collect: [ :each | Smalltalk at: each ])
			select: [ :each | each includesBehavior: self baseClass ] ].
	^ items asSet.