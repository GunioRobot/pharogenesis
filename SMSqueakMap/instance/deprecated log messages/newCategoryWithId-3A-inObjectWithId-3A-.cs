newCategoryWithId: catIdString inObjectWithId: idString
	"Add a category to a categorizable object."

	^(self objectWithId: idString) addCategory: (self categoryWithId: catIdString)
