messageCatListSingleton

	| name |
	name _ self selectedMessageCategoryName.
	^ name ifNil: [Array new]
		ifNotNil: [Array with: name]