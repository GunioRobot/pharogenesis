categoryOfCurrentMethod
	"Answer the category that owns the current method.  If unable to determine a category, answer nil."

	| aClass aSelector |
	^ (aClass _ self selectedClassOrMetaClass) ifNotNil: [(aSelector _ self selectedMessageName) ifNotNil: [aClass whichCategoryIncludesSelector: aSelector]]