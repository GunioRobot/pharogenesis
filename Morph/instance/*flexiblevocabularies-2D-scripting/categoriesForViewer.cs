categoriesForViewer
	"Answer a list of symbols representing the categories to offer in the 
	viewer, in order"
	| dict aList |
	dict := Dictionary new.
	self unfilteredCategoriesForViewer
		withIndexDo: [:cat :index | dict at: cat put: index].
	self filterViewerCategoryDictionary: dict.
	aList := SortedCollection
				sortBlock: [:a :b | (dict at: a)
						< (dict at: b)].
	aList addAll: dict keys.
	^ aList asArray