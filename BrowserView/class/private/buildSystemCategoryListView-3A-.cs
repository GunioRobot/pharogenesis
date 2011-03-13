buildSystemCategoryListView: aBrowser

	| aSystemCategoryListView |
	aSystemCategoryListView _ SystemCategoryListView new.
	aSystemCategoryListView model: aBrowser.
	aSystemCategoryListView window: (0 @ 0 extent: 50 @ 70).
	aSystemCategoryListView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
	^aSystemCategoryListView