moveCategory: category toAfter: categoryBefore inParent: parent
	"Move a category to be listed after <categoryBefore> in <parent>."

	parent move: category toAfter: categoryBefore.
	^category
	
