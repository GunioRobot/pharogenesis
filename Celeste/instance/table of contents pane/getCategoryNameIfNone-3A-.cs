getCategoryNameIfNone: aBlock
	"Prompt the user for a category name, remembering it for the next time."

	| catList categoryName |
	catList _ self categoryList.
	catList remove: '.all.' ifAbsent: [].
	catList remove: '.trash.' ifAbsent: [].
	catList remove: '.unclassified.' ifAbsent: [].
	catList add: '<new category>'.
	((lastCategoryList ~= catList) or: [lastCategoryMenu = nil])
		ifTrue: [lastCategoryMenu _ CustomMenu selections: catList].
	categoryName _ lastCategoryMenu startUp.
	categoryName = nil ifTrue: [^aBlock value].
	categoryName = '<new category>' ifTrue: [
		categoryName _ FillInTheBlank
			request: 'New category name?'
			initialAnswer: ''.
		(categoryName isEmpty) ifTrue: [^aBlock value].
		lastCategoryMenu _ nil.
		mailDB addCategory: categoryName.
		self changed: #categoryList.
	].
	lastCategoryList _ catList.
	^lastCategory _ categoryName