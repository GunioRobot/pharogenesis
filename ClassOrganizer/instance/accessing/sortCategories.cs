sortCategories
	| oldCategories |
	oldCategories _ self categories copy.
	SystemChangeNotifier uniqueInstance doSilently: [
		super sortCategories].
	self notifyOfChangedCategoriesFrom: oldCategories to: self categories.