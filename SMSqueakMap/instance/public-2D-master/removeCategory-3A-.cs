removeCategory: aCategory
	"Remove a category. Same as deleting it but we log it too."
self halt.

	self deleteCategory: aCategory.
	self logDelete: aCategory.
	^aCategory