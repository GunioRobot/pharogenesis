categoryList
	"Answer the category list for the protcol, creating it if necessary, and prepending the -- all -- category, and appending the other special categories for search results, etc."

	| specialCategoryNames |
	categoryList ifNil:
		[specialCategoryNames _ #(queryCategoryName  viewedCategoryName "searchCategoryName sendersCategoryName  changedCategoryName activeCategoryName")  collect:
			[:sym | self class perform: sym].
		categoryList _
			(currentVocabulary categoryListForInstance: self targetObject ofClass: targetClass limitClass: limitClass),
			specialCategoryNames,
			(Array with: self class allCategoryName)].
	^ categoryList