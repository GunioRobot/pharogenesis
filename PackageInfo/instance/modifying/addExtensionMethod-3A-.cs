addExtensionMethod: aMethodReference
	| category |
	category := self baseCategoryOfMethod: aMethodReference.
	aMethodReference actualClass organization
		classify: aMethodReference methodSymbol
		under: self methodCategoryPrefix, '-', category