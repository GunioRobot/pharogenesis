systemCategorySingleton

	| cls |
	cls _ self selectedClass.
	^ cls ifNil: [Array new]
		ifNotNil: [Array with: cls category name]