addExtensionMethod: aMethodReference
	| category |
	category _ self baseCategoryOfMethod: aMethodReference.
	aMethodReference actualClass organization
		classify: aMethodReference methodSymbol
		under: self methodCategoryPrefix, '-', category