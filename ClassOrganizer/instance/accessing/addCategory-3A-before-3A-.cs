addCategory: catString before: nextCategory
	| oldCategories |
	oldCategories _ self categories copy.
	SystemChangeNotifier uniqueInstance doSilently: [
		super addCategory: catString before: nextCategory].
	self notifyOfChangedCategoriesFrom: oldCategories to: self categories.