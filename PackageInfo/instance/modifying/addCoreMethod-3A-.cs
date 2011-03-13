addCoreMethod: aMethodReference
	| category |
	category := self baseCategoryOfMethod: aMethodReference.
	aMethodReference actualClass organization
		classify: aMethodReference methodSymbol
		under: category
		suppressIfDefault: false