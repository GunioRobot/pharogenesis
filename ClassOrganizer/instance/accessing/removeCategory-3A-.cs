removeCategory: cat 
	| oldCategories |
	oldCategories _ self categories copy.
	SystemChangeNotifier uniqueInstance doSilently: [
		super removeCategory: cat].
	self notifyOfChangedCategoriesFrom: oldCategories to: self categories.