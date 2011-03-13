categoriesAndPackagesIn: categoryPrefix
	| categories packages |
	categories := self categories select: [ :cat | cat isSubcategoryOf: categoryPrefix ].
	packages := self sortedPackages select: [ :p | p category = categoryPrefix ].
	^categories, packages