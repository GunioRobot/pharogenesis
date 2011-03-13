addCategoryNamed: aCategoryName
	"Add a category of the given name to my categories list,"

	categories add: (ElementCategory new categoryName: aCategoryName asSymbol)