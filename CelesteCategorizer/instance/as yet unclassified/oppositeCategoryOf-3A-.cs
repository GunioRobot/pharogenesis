oppositeCategoryOf: categoryName
	^ self categoryNamed:
		((categoryName beginsWith: 'not ')
			ifTrue: [categoryName copyFrom: 5 to: categoryName size]
			ifFalse: ['not ', categoryName])