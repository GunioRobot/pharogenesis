previousCategory
	"Select the next category."

	| catList i |
	catList _ self categoryList.
	(currentCategory isNil) ifTrue: [currentCategory _ catList last].
	i _ catList indexOf: currentCategory.
	i > 1
		ifTrue: [self setCategory: (catList at: i - 1)]
		ifFalse: [self setCategory: (catList at: catList size)].
