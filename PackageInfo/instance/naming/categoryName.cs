categoryName
	|category|
	category _ self class category.
	^ (category endsWith: '-Info')
		ifTrue: [category copyUpToLast: $-]
		ifFalse: [category]