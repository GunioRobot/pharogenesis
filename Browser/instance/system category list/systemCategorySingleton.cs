systemCategorySingleton

	| cat |
	cat _ self selectedSystemCategoryName.
	^ cat ifNil: [Array new]
		ifNotNil: [Array with: cat]