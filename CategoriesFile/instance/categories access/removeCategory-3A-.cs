removeCategory: categoryName
	"Remove the given category, if it exists."

	categories removeKey: categoryName ifAbsent: [].