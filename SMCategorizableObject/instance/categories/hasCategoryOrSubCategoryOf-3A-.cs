hasCategoryOrSubCategoryOf: aCategory
	"Answer true if I am in aCategory or if I am in any
	of its sub categories recursively."

	aCategory allCategoriesDo: [:cat |
		(self hasCategory: cat) ifTrue: [^ true]].
	^false