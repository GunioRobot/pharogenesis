changeFromCategorySpecs: categorySpecs
	| oldDict oldCategories |
	oldDict _ self elementCategoryDict.
	oldCategories _ self categories copy.
	SystemChangeNotifier uniqueInstance doSilently: [
		super changeFromCategorySpecs: categorySpecs].
	self notifyOfChangedSelectorsOldDict: oldDict newDict: self elementCategoryDict.
	self notifyOfChangedCategoriesFrom: oldCategories to: self categories.