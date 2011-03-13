subcategoriesOf: categoryPrefix
	^self categories select: [ :cat | cat isSubcategoryOf: categoryPrefix ]