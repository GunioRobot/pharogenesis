addCategoryFilter
	| category |
	category := self getCategoryNameAllowingAny: true ifNone: [ ^self ].
	self addFilter: (CelesteCategoryFilter forCategory: category)