removeEmptyCategories
	| oldCategories |
	oldCategories _ self categories copy.
	SystemChangeNotifier uniqueInstance doSilently: [
		super removeEmptyCategories].
	self notifyOfChangedCategoriesFrom: oldCategories to: self categories.