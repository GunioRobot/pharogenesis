selectedCategory
	"Return selected category."

	^(self selectedCategoryWrapper isNil)
		ifFalse: [self selectedCategoryWrapper withoutListWrapper]