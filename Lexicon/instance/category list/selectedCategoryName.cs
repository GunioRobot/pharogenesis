selectedCategoryName
	"Answer the selected category name"

	^ categoryList ifNotNil:
		[categoryList at: categoryListIndex ifAbsent: [nil]]