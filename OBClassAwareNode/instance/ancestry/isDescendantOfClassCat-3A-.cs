isDescendantOfClassCat: aClassCategoryNode

	"optimized version: sending #category to the class is slow"
	^ (self theNonMetaClass environment organization 
		listAtCategoryNamed: aClassCategoryNode name)
			includes: self theNonMetaClassName

