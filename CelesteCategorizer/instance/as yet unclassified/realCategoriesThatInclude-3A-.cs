realCategoriesThatInclude: x
	^ self realCategories select: [:categoryName | (categories at: categoryName) includes: x]