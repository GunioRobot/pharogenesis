moveCategory: category toParent: parentCategory
	"Move a category into another parent category."

	parentCategory
		ifNil: [category parent: nil]
		ifNotNil: [parentCategory addCategory: category].
	^category
	
