package: aPackage filteredByCategory: aCategory
	"Answer true if the package should be shown
	if we filter on <aCategory>. It should be shown
	if itself or any of its releases has the category."

	| releases |
	releases := aPackage releases.
	^(aPackage hasCategoryOrSubCategoryOf: aCategory) or: [
			releases anySatisfy: [:rel |
				rel hasCategoryOrSubCategoryOf: aCategory]]