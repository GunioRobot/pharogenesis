categoryOfCurrentMethod
	"Determine the category that owns the current method.  Return    
	the category name."

	^ self selectedClassOrMetaClass whichCategoryIncludesSelector: self selectedMessageName