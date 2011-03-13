updateSystemCategories
	"The class categories were changed in another browser. The receiver must 
	reorganize its lists based on these changes."

	self okToChange ifFalse: [^ self].
	self systemCategoryListIndex: 0.
	self changed: #systemCategoriesChanged