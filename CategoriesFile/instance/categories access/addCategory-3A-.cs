addCategory: categoryName 
	"Add a new category, if it doesn't already exist."
	(self categories includes: categoryName)
		ifFalse: [categories at: categoryName put: PluggableSet integerSet]